﻿using commercetools.Core.Common;

namespace commercetools.Core.TaxCategories
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the TaxCategoryManager.
        /// </summary>
        /// <returns>TaxCategoryManager</returns>
        public static TaxCategoryManager TaxCategories(this Client client)
        {
            return new TaxCategoryManager(client);
        }
    }
}
