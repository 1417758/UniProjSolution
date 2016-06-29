using MainWeb;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for MyValidation
/// </summary>
public class MyValidation {
    public MyValidation() {
        //
        // TODO: Add constructor logic here
        //
    }




    public class MyPasswordValidator : IIdentityValidator<string> {
        private PasswordValidator passValid;
        private UserManager userManage;

        //constructor 1
        public MyPasswordValidator(UserManager userManager) {
            this.userManage = userManager;
        }

        //constructor 1
        public MyPasswordValidator(PasswordValidator passwordValidator) {
            this.passValid = passwordValidator;
        }
        //constructor 2
        public MyPasswordValidator() {
            this.passValid.RequireLowercase = true ;
            this.passValid.RequireUppercase = false;
            this.passValid.RequireDigit = true;
            this.passValid.RequireNonLetterOrDigit = false;
            this.passValid.RequiredLength = 8;
        }

        public Task<IdentityResult> ValidateAsync(string item) {
            throw new NotImplementedException();
        }
    }

    public class MyUserValidator : IIdentityValidator<ApplicationUser> {
        private UserManager userManager;

        public MyUserValidator(UserManager userManager) {
            this.userManager = userManager;
        }

        public Task<IdentityResult> ValidateAsync(ApplicationUser item) {
            throw new NotImplementedException();
        }
    }



}