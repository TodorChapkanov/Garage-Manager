namespace GarageManager.Common.GlobalConstant
{
    public class CustomerCnstants
    {
        public const int RegisterNameMinLength = 3;
        public const int RegisterNameMaxLength = 30;
        public const string RegisterNameLengthErrorMessage = "{0} should be between {2} and {1} symbols!";
        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 30;
        public const string PasswordErrorMssage = "{0} should be between {2} and{1} symbold!";
        public const string ConfirmPasswordError = "Confirm Password and Password are not equal!";
        public const string InvalidPhoneNumber = "The Phone Number is not valid";
        public const int PhoneNumberMinLength = 8;
        public const int PhoneNumberMaxLength = 14;
        public const string InvalidCustomerEmailCode = "691099710";
        public const string ValidatePhonenNumberRegexPatern = @"^\+?\b[0-9]{8,13}\b";
        public const string PhoneNumberErrorMessage = "Phone number should be in one of the formats (+*************, 0************)";

    }
}

