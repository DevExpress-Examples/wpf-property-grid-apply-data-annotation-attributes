using System.IO;
using System.ComponentModel.DataAnnotations;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm.DataAnnotations;

namespace DXSample {
    public partial class MainWindow : DXWindow {
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
            };
            contact.Photo = GetPhoto(contact);
            DataContext = contact;
            InitializeComponent();
        }
        byte[] GetPhoto(Contact contact) {
            return GetPhoto(contact.FirstName + contact.LastName + ".jpg");
        }
        byte[] GetPhoto(string name) {
            return File.ReadAllBytes(@"Images\" + name);
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
        [RegExMaskAttribute(Mask = @"\w{1,25}", UseAsDisplayFormat = true, ShowPlaceHolders = false)]
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
        public byte[] Photo { get; set; }
    }
    public class ContactValidator {
        public static ValidationResult ValidateString(object value) {
            if (value == null || value.ToString().Length > 25)
                return new ValidationResult("Value is too long");
            return ValidationResult.Success;
        }
    }
}