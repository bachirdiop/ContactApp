using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using Xamarin.Forms;

namespace ContactApp.Services
{
    class ContactService : IDataStore<Contact>
    {
        ObservableCollection<Contact> ContactList;

        public ContactService()
        {
            ContactList = new ObservableCollection<Contact>();
            Random r = new Random();
            var mockContacts = new List<Contact>
            {
                new Contact { Id = Guid.NewGuid().ToString(), Name = "First Contact", CellNumber= r.Next(20,90)+"-"+r.Next(200000,900000),ImgSource  = ImageSource.FromResource("ContactApp.Images.profile.png") },
                new Contact { Id = Guid.NewGuid().ToString(), Name = "Second Contact", CellNumber=r.Next(20,90)+"-"+r.Next(200000,900000),ImgSource  = ImageSource.FromResource("ContactApp.Images.profile.png") },
                new Contact { Id = Guid.NewGuid().ToString(), Name = "Third Contact", CellNumber=r.Next(20,90)+"-"+r.Next(200000,900000),ImgSource  = ImageSource.FromResource("ContactApp.Images.profile.png") },
                new Contact { Id = Guid.NewGuid().ToString(), Name = "Fourth Contact", CellNumber=r.Next(20,90)+"-"+r.Next(200000,900000),ImgSource  = ImageSource.FromResource("ContactApp.Images.profile.png") },
                new Contact { Id = Guid.NewGuid().ToString(), Name = "Fifth Contact", CellNumber=r.Next(20,90)+"-"+r.Next(200000,900000),ImgSource  = ImageSource.FromResource("ContactApp.Images.profile.png")},
                new Contact { Id = Guid.NewGuid().ToString(), Name = "Sixth Contact", CellNumber=r.Next(20,90)+"-"+r.Next(200000,900000),ImgSource  = ImageSource.FromResource("ContactApp.Images.profile.png")},
            };

            foreach (var Contact in mockContacts)
            {
                ContactList.Add(Contact);
            }
        }

        public async Task<bool> AddContactAsync(Contact Contact)
        {
            ContactList.Add(Contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateContactAsync(Contact Contact)
        {
            var _Contact = ContactList.FirstOrDefault(arg => arg.Id == Contact.Id);
            ContactList.Remove(_Contact);
            ContactList.Add(Contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteContactAsync(Contact Contact)
        {
            var _Contact = ContactList.FirstOrDefault(arg => arg.Id == Contact.Id);
            ContactList.Remove(_Contact);

            return await Task.FromResult(true);
        }

        public async Task<Contact> GetContactAsync(string id)
        {
            return await Task.FromResult(ContactList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Contact>> GetContactListAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(ContactList);
        }
    }
}
