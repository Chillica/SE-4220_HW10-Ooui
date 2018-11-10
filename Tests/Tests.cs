using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW7;
using HW7.ViewModel;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        Book bk = new Book();
        Character character = new Character();
        MainViewModel vm = new MainViewModel();
        CmdViewModel cvm = new CmdViewModel();
        LocationTreeViewModel lvm = new LocationTreeViewModel(new ObservableCollection<Location>(new BindingList<Location>(new[] { new Location() { Name = "Mountain", Description = "Filled with trees and hills." } })));


        [Test]
        public void IsCharSelected()
        {
            vm.SelectedCharacter = character;
            Assert.IsNotNull(vm.SelectedCharacter);
        }

        [Test]
        public void IsCharListOpen()
        {
            cvm.IsCharListOpen = true;
            Assert.True(cvm.IsCharListOpen);
        }
        [Test]
        public void IsCharListClosed()
        {
            cvm.IsCharListOpen = false;
            Assert.False(cvm.IsCharListOpen);
        }
        [Test]
        public void IsBookTitleCreateCorrectly()
        {
            bk.Title = "Hello World!";
            Assert.IsNotEmpty(bk.Title);
        }
        [Test]
        public void IsBooksBindingListNotEmpty()
        {
            Assert.IsNotEmpty(vm.BookVm.Books);
        }
        [Test]
        public void IsCharactersBindingListNotEmpty()
        {
            vm.Characters = new BindingList<Character>();
            vm.Characters.Add(new Character() { FirstName = $"First Name", LastName = $"Last Name" });
            Assert.IsNotEmpty(vm.Characters);
        }
        [Test]
        public void IsLocationBeingSelected()
        {
  

        }
        [Test]
        public void IsLocationBeingAdded()
        {
            vm.LocVm.SelectedLocation = new Location();
            vm.LocVm.SelectedLocation.Name = "MyLocation";
            vm.LocVm.SelectedLocation.Children.Add(new Location() { Name = "Child" });

            Assert.AreEqual(1, vm.LocVm.SelectedLocation.Children.Count);
        }
        [Test]
        public void IsCharacterBeingAdded()
        {
            vm.Characters = new BindingList<Character>();
            vm.Characters.Add(new Character() { FirstName = $"First", LastName = $"Last" });
            vm.Characters.Add(new Character() { FirstName = $"First2", LastName = $"Last2" });
            vm.Characters.Add(new Character() { FirstName = $"First3", LastName = $"Last3" });
            Assert.AreEqual(3, vm.Characters.Count);
        }
        [Test]
        public void IsCharacterBeingRemoved()
        {
            vm.Characters = new BindingList<Character>();
            vm.Characters.Add(new Character() { FirstName = $"First", LastName = $"Last" });
            vm.Characters.Add(new Character() { FirstName = $"First2", LastName = $"Last2" });
            vm.Characters.Add(new Character() { FirstName = $"First3", LastName = $"Last3" });
            vm.Characters.RemoveAt(1);
            Assert.AreEqual(2, vm.Characters.Count);
        }
    }
}
