using Dapper;
using OneToOneDapper.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneToOneDapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var conn=new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                var sqlQuery = @"select Capitals.CapitalId,Capitals.Name,Capitals.CountryId,Countries.CountryId,Countries.Name
                            from Capitals
                            inner join Countries
                            on Capitals.CountryId=Countries.CountryId";
                var capitals = conn.Query<Capital, Country, Capital>(sqlQuery,(capital,country)=> 
                {
                    capital.Country = country;
                    return capital;
                },splitOn:"CountryId").ToList();
                mainGrid.ItemsSource = capitals;
            }
        }
    }
}
