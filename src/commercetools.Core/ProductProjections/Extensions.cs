﻿using commercetools.Core.Common;

namespace commercetools.Core.ProductProjections
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the ProductProjectionManager.
        /// </summary>
        /// <returns>ProductProjectionManager</returns>
        public static ProductProjectionManager ProductProjections(this Client client)
        {
            return new ProductProjectionManager(client);
        }
    }
}
