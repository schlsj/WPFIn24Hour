﻿using System;
using System.Collections.ObjectModel;
using ContactManager.Model;
using ContactManager.Views;

namespace ContactManager.Presenters
{
    public class ApplicationPresenter:PresenterBase<Shell>
    {
        private readonly ContactRepository _contactRepository;
        private ObservableCollection<Contact> _currentContacts;
        private string _statusText;

        public ApplicationPresenter(Shell view, ContactRepository contactRepository) : base(view)
        {
            _contactRepository = contactRepository;
            _currentContacts = new ObservableCollection<Contact>(_contactRepository.FindAll());
        }

        public ObservableCollection<Contact> CurrentContacts
        {
            get { return _currentContacts; }
            set
            {
                _currentContacts = value;
                OnPropertyChanged();
            }
        }

        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                OnPropertyChanged();
            }
        }

        public void Search(string criteria)
        {
            if (!string.IsNullOrEmpty(criteria) && criteria.Length > 2)
            {
                CurrentContacts=new ObservableCollection<Contact>(_contactRepository.FindByLookup(criteria));
                StatusText = $"{CurrentContacts.Count} contacts found.";
            }
        }

        public void SaveContact(Contact contact)
        {
            if (!CurrentContacts.Contains(contact))
            {
                CurrentContacts.Add(contact);
            }

            _contactRepository.Save(contact);
            StatusText = $"Contact '{contact.LookupName}' was saved.";
        }

        public void DeleteContact(Contact contact)
        {
            if (CurrentContacts.Contains(contact))
            {
                CurrentContacts.Remove(contact);
            }

            _contactRepository.Delete(contact);
            StatusText = $"Contact '{contact.LookupName}' was deleted.";
        }

        public void CloseTab<T>(PresenterBase<T> presenter)
        {
            View.RemoveTab(presenter);
        }

        public void NewContact()
        {
            OpenContact(new Contact());
        }

        private void OpenContact(Contact contact)
        {
            if (contact == null)
            {
                return;
            }
            View.AddTab(new EditContactPresenter(this,new EditContactView(), contact));
        }

        public void DisplayAllContacts()
        {
            throw new NotImplementedException();
        }
    }
}
