namespace NeedForCars.Web.Common
{
    public class GlobalConstants
    {
        // File path templates
        public const string MAKE_LOGO_PATH_TEMPLATE = @"wwwroot\images\makes\{0}.png";

        public const string GENERATION_PHOTO_PATH_TEMPLATE = @"wwwroot\images\generations\{0}\{1}.png";

        public const string USERCAR_PHOTO_PATH_TEMPLATE = @"wwwroot\images\userCars\{0}\{1}.png";


        // Error Messages
        // Global
        public const string REQUIRED_NAME = "You must enter a name.";
        //----Register
        public const string REGISTER_NAME_INVALID = "Only Latin, Cyrillic and dots are allowed.";
        //----Images
        public const string IMAGE_COLLECTION_INVALID = "One or more of the images selected are not in valid format.";
        public const string IMAGE_INVALID = "Image is not in valid format";
        public const string IMAGE_REQUIRED = "You must add at least one image";

        //----Engines
        public const string ENGINE_NAME_INVALID = "Engine name is not in valid format.";
        public const string FUELTYPE_INVALID = "Fuel type is not valid.";
        public const string ENGINE_NUMBERVALUE_INVALID = "Value must be betweeen {1} and {2}.";
        public const string ENGINE_CREATOR_INVALID = "Creator can only contain latin characters, dashes, dots, commas and spaces";
        public const string ENGINE_NUMBEROFCYLINDERS_INVALID = "An engine can only have between 1 and 18 cylinders";
        public const string ENGINE_VALVESPERCYLINDER_INVALID = "A cylinder can only have between 2 and 6 valves";

        //----Cars
        //--------Controller
        public const string CAR_PRODUCTION_YEAR_INVALID = "Invalid year";
        public const string CAR_ALREADY_EXISTS = "A car with those specs that already exists";
        //--------ViewModels
        public const string CAR_NUMBEROFGEARS_INVALID = "A gearbox can only have between 1 and 10 gears";
        public const string CAR_TOPSPEED_INVALID = "Cars can barely make it to {2} km/h. Value must be between {1} and {2}";


        //----Generations
        //--------Controller
        public const string GENERATION_ALREADY_EXISTS = "Generation already exists";
        //--------ViewModels
        public const string GENERATION_NAME_LENGTH = "Generation name must be at least {2} and at max {1} characters long.";
        public const string GENERATION_NAME_INVALID = "Generation name can only contain Latin characters, brackets, dashes, dots and spaces";
        public const string GENERATION_BODYTYPE_INVALID = "Invalid body type";
        public const string GENERATION_SEATS_INVALID = "Seats must be a number between {1} and {2}";

        //----Makes
        //--------Controller
        public const string MAKE_ALREADY_EXISTS = "Make already exists";
        //--------ViewModels
        public const string MAKE_NAME_INVALID = "Make name can only contain Latin characters, spaces, dots and dashes";
        public const string MAKE_LOGO_REQUIRED = "You must add a logo image";
        public const string MAKE_DESCRIPTION_TOO_LONG = "Description must not be more than {1} characters long.";


        //----Models
        //--------Controller
        public const string MODEL_ALREADY_EXISTS = "Model already exists";
        //--------ViewModels
        public const string MODEL_NAME_INVALID = "Model name can only contain Latin characters, numbers, spaces, dots and dashes";

        //----UserCars
        //--------Controller
        public const string USERCAR_PRODUCTIONDATE_INVALID = "This car is only produced between {0} and {1}";
        //--------ViewModels
        public const string USERCAR_COLOR_REQUIRED = "You must enter a color for your car";
        public const string USERCAR_PRODUCTIONDATE_REQUIRED = "You must enter a production date for your car";
        public const string USERCAR_MILEAGE_REQUIRED = "You must enter your car's mileage";
        public const string USERCAR_MILEAGE_INVALID = "Mileage must be a number between {0} and {1}";
        public const string USERCAR_CAR_REQUIRED = "You must select a car";
        public const string USERCAR_PRICE_INVALID = "Car price must be between {0} and {1}";
        public const string USERCAR_PHOTOS_REQUIRED = "You must add photos of your car.";

        //----Messages
        //--------Controller
        public const string MESSAGE_RECEIVER_INVALID = "User with that username does not exist.";
        //--------ViewModels
        public const string MESSAGE_CONTENT_REQUIRED = "Your message must have content";
        public const string MESSAGE_CONTENT_TOO_LONG = "Message cannot be longer than {1} characters.";
        public const string MESSAGE_RECEIVER_REQUIRED = "Your message must have a receiver.";


        // Regular Expressions
        public const string EMAIL_REGEX = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                               + "@"
                               + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

        public const string USERNAME_REGEX = "[A-Za-z0-9._]{3,20}";

        public const string MAKE_NAME_REGEX = "[A-Za-z-. ]{2,}";

        public const string CAR_NAME_REGEX = "[A-Za-z 0-9]+";

        public const string GENERATION_NAME_REGEX = "[a-zA-Z0-9 ()-.]+";

        public const string ENGINE_NAME_REGEX = @"\d.\d( ?[A-Za-z0-9 ]+)?";

        public const string ENGINE_CREATOR_REGEX = @"[A-Za-z.\-, ]+";
    }
}
