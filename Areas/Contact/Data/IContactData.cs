using ASP_NET_MVC.Models;
using System.Collections.Generic;
namespace ASP_NET_MVC.Data{
    public interface IContactData{

        void CreateContact(ContactModel contact);
        List<ContactModel> Getcontacts();
        

    }
}