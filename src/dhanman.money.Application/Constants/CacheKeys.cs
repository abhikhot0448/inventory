namespace dhanman.money.Application.Constants
{
    public static class CacheKeys
    {
        #region Vendors
        public static class Vendors
        {
            public const string CacheKeyPrefix = "vendors-{0}";

            public const string vendorList = "vendors-{0}-list-{1}-{2}";

            public const string vendorById = "vendors-{0}-by-id-{1}";
        }
        #endregion

        #region VendorTypes
        public static class VendorTypes
        {
            public const string CacheKeyPrefix = "vendorTypes-{0}";

            public const string vendorTypeList = "vendorTypes-{0}-list-{1}-{2}";

            public const string vendorTypeById = "vendorTypes-{0}-by-id-{1}";
        }
        #endregion


        #region BillHeaders

        public static class BillHeaders
        {
            public const string CacheKeyPrefix = "billHeaders-{0}";

            public const string BilllHeaderList = "billHeaders-{0}-list-{1}";

            public const string BillHeaderById = "billHeaders-{0}-by-id-{1}";
        }

        #endregion


        #region BillDetails

        public static class BillDetails
        {
            public const string CacheKeyPrefix = "billDetails-{0}";

            public const string BilllDetailList = "billDetails-{0}-list-{1}";

            public const string BillDetailById = "billDetails-{0}-by-id-{1}";
        }

        #endregion


        #region Bills

        public static class Bills
        {
            public const string CacheKeyPrefix = "bills-{0}";

            public const string BillList = CacheKeyPrefix + "-list-{1}";

            
        }
        #endregion

        #region BillStatus

        public static class BillStatuses
        {
            public const string CacheKeyPrefix = "billStatuses-{0}";

            public const string BillStatusList = "billStatuses-{0}-list-{1}";

            public const string BillStatusById = "billStatuse-{0}-by-id-{1}";
        }

        #endregion

        #region BillPayments

        public static class BillPayments
        {
            public const string CacheKeyPrefix = "billPayments-{0}";

            public const string BillPaymentList = CacheKeyPrefix + "-list-{1}";

            public const string BillPaymentById = CacheKeyPrefix + "-by-id-{1}-{2}";
        }

        #endregion
    }
}
