using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo1.Context;
using demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demo1;

public partial class Order : Window
{
    List<Productsmaterial> alltovar = new List<Productsmaterial>();
    public Order()
    {
        InitializeComponent();
        var all = Helper.DataBase.Productsmaterials.ToList();
        var all1 = Helper.DataBase.Idformatorprods.ToList();
        List<string> products = new List<string>();
        foreach (var item in all)
        {
            foreach (var id in all1)
            {
                if (id.Id == 2)
                {
                    if(item.Prodormatid == id.Id)
                    {
                        products.Add($"Name:{item.Name} Price:{item.Price}");
                        alltovar.Add(item);
                    }
                }
            }
        }
        tovars.ItemsSource = products;
    }

    private void Button_Add_InCart(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        List<string> products = new List<string>();
        
        int _kolvo = Convert.ToInt32(kolvo.Text);
        
        
      



        Cart.ItemsSource = products;
        Close();
    }
}