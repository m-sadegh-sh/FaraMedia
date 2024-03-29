﻿namespace FaraMedia.Web.Framework.Storage {
    public static class StatefulStorage {
        public static IStatefulStorage PerApplication {
            get { return new StatefulStoragePerApplication(); }
        }

        public static IStatefulStorage PerRequest {
            get { return new StatefulStoragePerRequest(); }
        }

        public static IStatefulStorage PerSession {
            get { return new StatefulStoragePerSession(); }
        }
    }
}