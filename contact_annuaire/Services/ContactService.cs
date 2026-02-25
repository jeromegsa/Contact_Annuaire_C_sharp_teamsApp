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
        public void AjouterContact(Contact contact)
        {
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);

        }
        public void ModifierContact(Contact contactModifie)
        {
            // On trouve le contact existant par son Id
            var contact = _contacts.FirstOrDefault(c => c.Id == contactModifie.Id);
            if (contact != null)
            {
                // On met à jour ses propriétés
                contact.Prenom = contactModifie.Prenom;
                contact.Nom = contactModifie.Nom;
                contact.Email = contactModifie.Email;
                contact.Telephone = contactModifie.Telephone;
            }
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
