using DevExpress.Mvvm.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DXSample {
    public partial class MainWindow : Window {
        public MainWindow() {
            var contact = new Contact {
                FirstName = "Carolyn",
                LastName = "Baker",
                Email = "carolyn.baker@example.com",
                Phone = "(555)349-3010",
                Address = "1198 Theresa Cir",
                City = "Whitinsville",
                State = "MA",
                Zip = "01582",
                Photo = new BitmapImage(new System.Uri("pack://application:,,,/Images/CarolynBaker.jpg"))
            };
            DataContext = contact;
            InitializeComponent();
        }
    }
    public class Contact {
        [Display(GroupName = "General Info")]
        [Required]
        [MaxLength(25, ErrorMessage = "Value is too long")]
        public string FirstName { get; set; }

        [Display(GroupName = "General Info")]
        [Required]
        public string LastName { get; set; }

        [Display(GroupName = "General Info", AutoGenerateField = false)]
        [DisplayFormat(NullDisplayText = "<empty>")]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Display(GroupName = "Contacts")]
        [DisplayFormat(NullDisplayText = "<empty>")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(GroupName = "Contacts")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(NullDisplayText = "<empty>")]
        public string Phone { get; set; }

        [Display(GroupName = "Address")]
        [DisplayFormat(NullDisplayText = "<empty>")]
        public string Address { get; set; }

        [Display(GroupName = "Address")]
        [DisplayFormat(NullDisplayText = "<empty>")]
        [RegExMask(Mask = @"\w{1,25}", UseAsDisplayFormat = true, ShowPlaceHolders = false)]
        public string City { get; set; }

        [Display(GroupName = "Address")]
        [DisplayFormat(NullDisplayText = "<empty>")]
        [CustomValidation(typeof(ContactValidator), "ValidateString")]
        public string State { get; set; }

        [Display(GroupName = "Address")]
        [DisplayFormat(NullDisplayText = "<empty>")]
        public string Zip { get; set; }

        [Display(GroupName = "General Info")]
        [PropertyGridEditor(TemplateKey = "ImageTemplate")]
        public ImageSource Photo { get; set; }
    }
    public class ContactValidator {
        public static ValidationResult ValidateString(object value) {
            if (value == null || value.ToString().Length > 25)
                return new ValidationResult("Value is too long");
            return ValidationResult.Success;
        }
    }
}