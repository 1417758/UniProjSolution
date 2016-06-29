using MainWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MyClass
/// </summary>
public class MyClass : ApplicationUser {

    //variables
    public string First { get; set; }
    public string Last { get; set; }
    public string Age { get; set; }
    public string EmailReg { get; set; }


    //constructor
    public MyClass()  {
        //
        // TODO: Add constructor logic here
        //
    }
    //public MyClass(ApplicationUser webUser);

    protected void CreateUser_Click(object sender, EventArgs e) {
        var manager = new UserManager();
        var endUser = new ApplicationUser() { UserName = "Rachie" };
    }




}
