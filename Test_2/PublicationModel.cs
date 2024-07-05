using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PublicationModel 
    {
        private List<Publication> publications = new List<Publication>();
        public List<Publication> GetPublications()
        {
            return publications;
        }
        public void AddPublication(Publication publication)
        {
            publications.Add(publication);
        }
        public void RemovePublication(int id)
        {
            publications.RemoveAll(publication => publication.Id == id);
        }
        public void EditPublication(Publication publication)
        {
            publications.Remove(publication);
        }
    }
}