using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.tests.Pages.LoginPage
{
    public static class LoginPageAsserts
    {
        public static void AssertLoginWithExistingUser (this LoginPage logPage)
        {
            Assert.AreEqual("Hello existing_mail@sm.bg!", logPage.ManageButton.Text);
        }
        public static void AssertLoginPasswordIsRequired(this LoginPage logPage)
        {
            Assert.AreEqual("The Password field is required.", logPage.PasswordFieldRequiredMessage.Text);
        }
        public static void AssertLoginEmailAndPasswordIsRequired(this LoginPage logPage)
        {
            Assert.AreEqual("The Email field is required.", logPage.EmailFieldRequiredMessage.Text);
            Assert.AreEqual("The Password field is required.", logPage.PasswordFieldRequiredMessage.Text);
        }
        public static void AssertLoginWithWrongPassword(this LoginPage logPage)
        {
            Assert.AreEqual("Invalid login attempt.", logPage.WrongPasswordMessage.Text);
        }
    }
}
