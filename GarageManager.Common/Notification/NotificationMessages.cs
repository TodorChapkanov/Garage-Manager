namespace GarageManager.Common.Notification
{
    public class NotificationMessages
    {
        public const string InvalidOperation = "Invalid operation!";
        public const string DeleteCurentUserErrorMessage = "You cannot delete yourself";

        public const string CarCreatedSuccessfull = "Car with registarion plate {0} was added successfully";
        public const string CarCreateFail = "Adding a new car is failed";
        public const string CarUpdatedSuccessfull = "Car was updated successfully";
        public const string CarEditFail = "Update Car data  failed";
        public const string CarNotExist = "The car does not exist in database";
        public const string CarDeletedSuccessfull = "Car was deleted successfully";

        public const string CustomerCreateSuccessfull = "Customer {0} {1} was added successesfully";
        public const string CustomerEditSuccessfull = "Customer details was updated successfully";
        public const string CustomerDeleteSuccessfull = "Customer was delete successfully";
        public const string CustomerOrderCompletedSuccessfully = "The order was completed successfully";
        public const string CustomerNotExist = "The customer does not exist";
        public const string InvalidCustomerEmail = "Customer with Email {0} already exist";

        public const string EmailExist = "This email is already registered";
        public const string EmployeeCreateSuccessfull = "Employee {0} {1} is added successfully";
        public const string EmployeeEditSuccessfull = "Employee details was updated successfully";
        public const string EmployeeDeleteSuccessfull = "Employee was seleted successfully";
        public const string EmployeeNotExist = "TThe Employee does not exist";

        public const string CarServiceAdded = "Car was added in department for service";
        public const string CarAddToServiceFail = "Add Car for Service failed";
        public const string CarServiceCmpletedSuccessfull = "Service was finished successfullly";
        public const string CarServiceNotCompleted = "Service was not finished";
        public const string CreateCarModelIsRequired = "Car Model is Required";

        public const string PartCreateSuccessfull = "Part with number-{0} was added successfully";
        public const string PartEditSuccessfull = "Part was updated successflly";
        public const string PartDeleteSuccessfull = "The part was deleted successfully";
        public const string PartNotExist = "The Part Does not exist";

        public const string RepairServiceCreateSuccessfull = "Reapir Service was added successflly";
        public const string RepairServiceEditSuccessfull = "Reapir Service was updated successflly";
        public const string RepairServiceDeleteSuccessfull = "Repair Service was deleted successfully";


        public const string EmailExistResult = "EmailExist";
        public const string EmailExistErrorMessage = "Invalid Email";
    }
}
