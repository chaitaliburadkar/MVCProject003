using MVCProject003.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject003.Models
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Email_ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Srno { get; set; }

        public string Savereg(ContactModel model)
        {
            string msg = "Data Saved Successfully!";
            MVCProject003Entities Db = new MVCProject003Entities();
            var reg = Db.tblContacts.Where(p => p.ID == model.ID).FirstOrDefault();
            if (model.ID == 0)
            {
                var regData = new tblContact()
                {
                    ID = model.ID,
                    Name = model.Name,
                    Mobile_No = model.Mobile_No,
                    Email_ID = model.Email_ID,
                    Address = model.Address,
                    City = model.City,
                };

                Db.tblContacts.Add(regData);
                Db.SaveChanges();
                
            }
            else
            {
                reg.ID = model.ID;
                reg.Name = model.Name;
                reg.Mobile_No = model.Mobile_No;
                reg.Email_ID = model.Email_ID;
                reg.Address = model.Address;
                reg.City = model.City;

                Db.SaveChanges();
                msg = "Update successfully!";
            }

            return msg;
        }

    

        public List<ContactModel> GetDataList()
        {
            MVCProject003Entities Db = new MVCProject003Entities();
            List<ContactModel> lstContact = new List<ContactModel>();
            var AddContactList = Db.tblContacts.ToList();
            int Srno = 1;
            if (AddContactList != null)
            {
                foreach (var Contact in AddContactList)
                {
                    lstContact.Add(new ContactModel()
                    {
                        Srno = Srno,
                        ID = Contact.ID,
                        Name = Contact.Name,
                        Mobile_No = Contact.Mobile_No,
                        Email_ID = Contact.Email_ID,
                        Address = Contact.Address,
                        City = Contact.City,
                    });
                    Srno++;
                }
            }
            return lstContact;
        }

        public string DeleteContact(int Id)
        {
            var massage = "Delete Successfull";
            MVCProject003Entities Db = new MVCProject003Entities();
            var data = Db.tblContacts.Where(p => p.ID == Id).FirstOrDefault();
            if (data != null)
            {
                Db.tblContacts.Remove(data);
                Db.SaveChanges();

            }
            return massage;
        }

        public ContactModel GetContactbyId(int Id)
        {
            ContactModel model = new ContactModel();
            MVCProject003Entities Db = new MVCProject003Entities();
            var data = Db.tblContacts.Where(p => p.ID == Id).FirstOrDefault();
            if (data != null)
            {
                model.ID = data.ID;
                model.Name = data.Name;
                model.Mobile_No = data.Mobile_No;
                model.Email_ID = data.Email_ID;
                model.Address = data.Address;
                model.City = data.City;
            };
            return model;
        }

    }
}




