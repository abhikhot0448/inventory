namespace dhanman.money.Api.Contracts
{
    public static class ApiRoutes
    {

        public const string apiVersion = "api/v{version:apiVersion}/";
      

        public static class BillHeaders
        {
            public const string GetAllBillHeaders = apiVersion + "GetAllBillHeaders";

            public const string CreateBillHeaders = apiVersion + "billHeaders";

            public const string GetBillHeaderesById = apiVersion + "billHeaders/{id:guid}";
        }
        public static class BillDetails
        {
            public const string GetAllBillDetails = apiVersion + "GetAllBillDetails";

            public const string CreateBillDetails = apiVersion + "billDetails";

            public const string GetBillDetailsById = apiVersion + "billDetails/{id:guid}";
        }

        public static class Bills
        {
            public const string GetAllBills = apiVersion + "GetAllBills/{clientId:guid}";

            public const string CreateBill = apiVersion + "bill";
        }


        public static class BillStatuses
        {
            public const string GetAllBillStatuses = apiVersion + "GetAllBillStatuses";

            public const string CreateBillStatus = apiVersion + "billStatus";

            public const string GetBillStatusById = apiVersion + "billStatuses/{id:guid}";
        }


        public static class Authentication
        {
            public const string Login = "authentication/login";

            public const string Register = "authentication/register";
        }

        public static class BillPayments
        {
            public const string GetBillPayments = apiVersion + "GetAllBillPayments";

            public const string CreateBillPayments = apiVersion + "billPayments";

            public const string GetBillPaymentsById = apiVersion + "billPayments/{id:guid}";
        }
    }
}
