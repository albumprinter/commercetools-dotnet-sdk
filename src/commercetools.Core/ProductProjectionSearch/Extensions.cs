﻿using commercetools.Core.Common;

namespace commercetools.Core.ProductProjectionSearch
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the ProductProjectionSearchManager.
        /// </summary>
        /// <returns>ProductProjectionSearchManager</returns>
        public static ProductProjectionSearchManager ProductProjectionSearch(this Client client)
        {
            return new ProductProjectionSearchManager(client);
        }
    }
}
