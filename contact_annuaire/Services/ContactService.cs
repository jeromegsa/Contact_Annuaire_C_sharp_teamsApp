using contact_annuaire.Models;

namespace contact_annuaire.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>
        {
            new Contact { Id = 1, Nom = "Doe", Prenom = "John", Email = "jeff@iii.com", Telephone = "1234567890" },
            new Contact { Id = 2, Nom = "Smith", Prenom = "Jane", Email = "jane@iii.com", Telephone = "0987654321" }
        };


        public List<Contact> GetContacts()
        {
            return _contacts;
        }
        public void AjouterContact(Contact Contact)
        {
            Contact.Id = _contacts.Count + 1;
        }
        public void SupprimerContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c=>c.Id==id);
            if(contact != null)
            {
                _contacts.Remove(contact);
            }
        }
    }
}
