﻿using System;
#if net40
using System.Linq;
#endif
using System.Collections.Concurrent;
using System.Reflection;

namespace MyCouch.Serialization.Meta
{
    public class DocumentSerializationMetaProvider : IDocumentSerializationMetaProvider
    {
        protected const string AnonymousTypePrefix = "<>";

        protected readonly ConcurrentDictionary<Type, DocumentSerializationMeta> Cache;

        public DocumentSerializationMetaProvider()
        {
            Cache = new ConcurrentDictionary<Type, DocumentSerializationMeta>();
        }

        public virtual DocumentSerializationMeta Get(Type docType)
        {
            return Cache.GetOrAdd(docType, CreateFor);
        }

        protected virtual DocumentSerializationMeta CreateFor(Type docType)
        {
            var isAnonymous = CheckIfDocTypeIsAnonymous(docType);
            var metaAttr = ExtractMetaDataAttribute(docType);
            var type = metaAttr == null ? docType.Name : metaAttr.DocType ?? docType.Name;

            var meta = new DocumentSerializationMeta(type, isAnonymous);
            if (metaAttr != null)
            {
                meta.DocNamespace = metaAttr.DocNamespace;
                meta.DocVersion = metaAttr.DocVersion;
            }

            return meta;
        }

        protected virtual DocumentAttribute ExtractMetaDataAttribute(Type docType)
        {
#if NETFX_CORE
            return docType.GetTypeInfo().GetCustomAttribute<DocumentAttribute>();

#elif net40
            return docType.GetCustomAttributes(typeof (DocumentAttribute), true).FirstOrDefault() as DocumentAttribute;
#else
            return docType.GetCustomAttribute<DocumentAttribute>(true);
#endif
        }

        protected virtual bool CheckIfDocTypeIsAnonymous(Type docType)
        {
#if !NETFX_CORE
            return docType.IsClass &&
                docType.IsNotPublic &&
                docType.IsSealed &&
                docType.IsGenericType &&
                docType.BaseType == typeof(object) &&
                docType.Namespace == null &&
                docType.Name.StartsWith(AnonymousTypePrefix);
#else
            var info = docType.GetTypeInfo();

            return info.IsClass &&
                info.IsNotPublic &&
                info.IsSealed &&
                info.IsGenericType &&
                info.BaseType == typeof(object) &&
                info.Namespace == null &&
                info.Name.StartsWith(AnonymousTypePrefix);
#endif
        }
    }
}