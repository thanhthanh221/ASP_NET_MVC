using ASP_NET_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ASP_NET_MVC.Data{
    public class ContactData : IContactData
    {
        // Inj dữ liệu từ trong Db vào đây
        private readonly Context context;

        public ContactData(Context context)
        {
            this.context = context;
        }


        public void CreateContact(ContactModel contact)
        {
            context.Add(contact);
            context.SaveChanges();
        }

        public List<ContactModel> Getcontacts()
        {
            var kq = context.contacts.ToList();
            return kq;
        }
    }
}
