using System.Diagnostics;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ShowAll(object sender, RoutedEventArgs e)
        {
            ShowAllEntities();
        }

        private void AddNew_Button(object sender, RoutedEventArgs e)
        {
            AddNewEntities();
        }

        private void Remove_Button(object sender, RoutedEventArgs e)
        {
            RemoveEntities();
        }

        private void Edit_button(object sender, RoutedEventArgs e)
        {
            EditEntities();
        }

        //показ всех записей класса Products и их производных
        public void ShowAllEntities ()
        {
            using (AppContext db = new AppContext())
            {
                try
                {
                    var products = db.Products.ToList();
                    tBox.Text = "All products from DB:\n";
                    foreach (var item in products)
                    {
                        tBox.Text += $"Name is: {item.Name}; Descriprion is: {item.Description}; Price is: {item.Price}\n";
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };
            }
        }


        public void AddNewEntities()
        {
            using (AppContext db = new AppContext())
            {
                try
                {
                    //для наглядности добавляются два унаследованных класса Одежда и Технологии
                    db.Products.Add(new Clothing { Name = "NewCloth", Description = "New added cloth to try test adding", Price = 111, ClothingProperty = "Some properties", ManagerId = 1 });
                    db.Products.Add(new Technology { Name = "NewTech", Description = "New added tech to try test adding", Price = 999, TechProperty = "Some tech properties",  ManagerId = 1 });
                    db.SaveChanges();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };

            }
        }


        public void EditEntities()
        {
            using (AppContext db = new AppContext())
            {
                try
                {
                    var itemToEdit = db.Products.FirstOrDefault(x => x.Name == "NewCloth");
                    var itemToEdit2 = db.Products.FirstOrDefault(x => x.Name == "NewTech");
                    if (itemToEdit != null) itemToEdit.Description = "Edited Description!";
                    if (itemToEdit2 != null) itemToEdit2.Description = "Edited Description!";
                    db.SaveChanges();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };

            }
        }

        public void RemoveEntities()
        {
            using (AppContext db = new AppContext())
            {
                try
                {
                    //удаляются только вновь добавленные записи новаяОдежда и новаяТехника (для упрощения программы)
                    var itemToRemove = db.Products.FirstOrDefault(x => x.Name == "NewCloth");
                    var itemToRemove2 = db.Products.FirstOrDefault(x => x.Name == "NewTech");
                    if (itemToRemove != null) db.Remove(itemToRemove);
                    if (itemToRemove2 != null) db.Remove(itemToRemove2);
                    db.SaveChanges();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); };
            }
        }
    }
}