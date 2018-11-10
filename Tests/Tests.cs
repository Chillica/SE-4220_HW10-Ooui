using NUnit.Framework;
using System.ComponentModel;
using System.Collections.ObjectModel;

using HW10;
using HW10.Shared;
using HW10.Shared.ViewModel;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        Book bk = new Book();
        Character character = new Character();
        MainViewModel vm = new MainViewModel(new WpfPlatformServices());
        CmdViewModel cvm = new CmdViewModel();
        LocationTreeViewModel lvm = 
            new LocationTreeViewModel(new ObservableCollection<Location>
                (new BindingList<Location>(new[] { new Location()
                { Name = "Mountain", Description = "Filled with trees and hills." } })),
                new WpfPlatformServices());


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
            vm.Characters = new BindingList<Character>
            {
                new Character() { FirstName = $"First Name", LastName = $"Last Name" }
            };
            Assert.IsNotEmpty(vm.Characters);
        }
        [Test]
        public void IsLocationBeingSelected()
        {
  

        }
        [Test]
        public void IsLocationBeingAdded()
        {
            vm.LocVm.SelectedLocation = new Location
            {
                Name = "MyLocation"
            };
            vm.LocVm.SelectedLocation.Children.Add(new Location() { Name = "Child" });

            Assert.AreEqual(1, vm.LocVm.SelectedLocation.Children.Count);
        }
        [Test]
        public void IsCharacterBeingAdded()
        {
            vm.Characters = new BindingList<Character>
            {
                new Character() { FirstName = $"First", LastName = $"Last" },
                new Character() { FirstName = $"First2", LastName = $"Last2" },
                new Character() { FirstName = $"First3", LastName = $"Last3" }
            };
            Assert.AreEqual(3, vm.Characters.Count);
        }
        [Test]
        public void IsCharacterBeingRemoved()
        {
            vm.Characters = new BindingList<Character>
            {
                new Character() { FirstName = $"First", LastName = $"Last" },
                new Character() { FirstName = $"First2", LastName = $"Last2" },
                new Character() { FirstName = $"First3", LastName = $"Last3" }
            };
            vm.Characters.RemoveAt(1);
            Assert.AreEqual(2, vm.Characters.Count);
        }
    }
}
