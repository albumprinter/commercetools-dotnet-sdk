﻿using commercetools.Core.Common;

namespace commercetools.Core.Customers
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates an instance of the CustomerManager.
        /// </summary>
        /// <returns>CustomerManager</returns>
        public static CustomerManager Customers(this Client client)
        {
            return new CustomerManager(client);
        }
    }
}
