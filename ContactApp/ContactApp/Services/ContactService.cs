using System;
using System.Collections.Generic;
using ContactApp.Models;
using Xamarin.Forms;

namespace ContactApp.Services
{
    internal class ContactService /* : SL.IDataStore<Contact>*/
    {
        //public IDataStore<Contact> ContactList;

        public ContactService()
        {
            //ContactList = new ObservableCollection<Contact>();
            var r = new Random();
            var mockContacts = new List<Contact>
            {
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "First Contact",
                    CellNumber = r.Next(20, 90) + "-" + r.Next(200000, 900000),
                    ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Second Contact",
                    CellNumber = r.Next(20, 90) + "-" + r.Next(200000, 900000),
                    ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Third Contact",
                    CellNumber = r.Next(20, 90) + "-" + r.Next(200000, 900000),
                    ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Fourth Contact",
                    CellNumber = r.Next(20, 90) + "-" + r.Next(200000, 900000),
                    ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Fifth Contact",
                    CellNumber = r.Next(20, 90) + "-" + r.Next(200000, 900000),
                    ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
                },
                new Contact
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sixth Contact",
                    CellNumber = r.Next(20, 90) + "-" + r.Next(200000, 900000),
                    ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
                }
            };

            //foreach (var Contact in mockContacts)
            //{
            //    ContactList.AddContactAsync(Contact);
            //}
        }

        //public async Task<bool> AddContactAsync(Contact Contact)
        //{
        //    ContactList.Add(Contact);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateContactAsync(Contact Contacte)
        //{
        //    var _Contact = ContactList.FirstOrDefault(arg => arg.Id == Contacte.Id);
        //    ContactList.Remove(_Contact);
        //    ContactList.Add(Contacte);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteContactAsync(Contact Contacte)
        //{
        //    var _Contact = ContactList.FirstOrDefault(arg => arg.Id == Contacte.Id);
        //    ContactList.Remove(_Contact);

        //    return await Task.FromResult(true);
        //}

        //public async Task<Contact> GetContactAsync(string id)
        //{
        //    return await Task.FromResult(ContactList.FirstOrDefault(s => s.Id == id));
        //}

        //public async Task<IEnumerable<Contact>> GetContactListAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(ContactList);
        //}

        //public async Task<int> AddAsync(Contact item)
        //{
        //    ContactList.Add(item);

        //    return await Task.FromResult(GetHashCode());
        //}

        //public async Task<int> UpdateAsync(Contact item)
        //{
        //    var _Contact = ContactList.FirstOrDefault(arg => arg.Id == item.Id);
        //    ContactList.Remove(_Contact);
        //    ContactList.Add(item);

        //    return await Task.FromResult(GetHashCode());
        //}

        //public async Task<int> DeleteAsync(Contact item)
        //{
        //    var _Contact = ContactList.FirstOrDefault(arg => arg.Id == item.Id);
        //    ContactList.Remove(item);

        //    return await Task.FromResult(GetHashCode());
        //}

        //public async Task<IEnumerable<Contact>> GetAllAsync(Expression<Func<Contact, bool>> expressions = null)
        //{
        //    return await Task.FromResult(ContactList);
        //}

        //public void CreateTableAsync21()
        //{
        //   ContactList = new ObservableCollection<Contact>();
        //}

        //public async Task<int> DropTableAsync()
        //{
        //    ContactList.Clear();
        //    return await Task.FromResult(ContactList.Count);
        //}
    }
}