using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_2
{
    public class PublicationController
    {
        private PublicationModel model;
        private MainWindow view;
        public PublicationController(PublicationModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
            LoadPublications();
        }
        public void LoadPublications()
        {
            view.PublicationListBox.Items.Clear();
            foreach(var publication in model.GetPublications())
            {
                view.PublicationListBox.Items.Add($"{publication.Name} - {publication.Description}");
            }
        }
        public void AddPublication(string name, string description)
        {
            var newPublication = new Publication
            {
                Id = model.GetPublications().Count + 1,
                Name = name,
                Description = description
            };
            model.AddPublication(newPublication);
            LoadPublications();
        }

        public void RemovePublication(ItemCollection items)
        {
            model.RemovePublication(model.GetPublications().Count);
            LoadPublications();
        }
        public void EditPublication(string editedName, string editedDescription)
        {
            var editPublication = new Publication
            {
                Id = model.GetPublications().Count,
                Name = editedName,
                Description = editedDescription
            };
            model.EditPublication(editPublication);
            LoadPublications();
        }
    }
    public partial class MainWindow : Window
    {
        public readonly PublicationController controller;
        public MainWindow()
        {
            InitializeComponent();
            var model = new PublicationModel();
            controller = new PublicationController(model, this);
        }
        private void AddPublication_Click(object sender, RoutedEventArgs e)
        {
            controller.AddPublication(PublicationNameTextBox.Text, PublicationDescriptionTextBox.Text);
            PublicationNameTextBox.Clear();
            PublicationDescriptionTextBox.Clear();
        }

        private void EditPublication_Click(object sender, RoutedEventArgs e)
        {
            controller.EditPublication(PublicationNameTextBox.Text, PublicationDescriptionTextBox.Text);
        }

        private void RemovePublication_Click(object sender, RoutedEventArgs e)
        {
            controller.RemovePublication(PublicationListBox.Items);
            PublicationListBox.Items.Clear();
        }
    }
}