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
    }
}
