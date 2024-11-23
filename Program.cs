namespace CsharpPracice
{
  class ContactApp
  {
    public class Contact
    {
      public string contactName { get; set; }
      public string contactPhone { get; set; }
      public string contactEmail { get; set; }

      public Contact(string name, string phone, string email)
      {
        contactName = name;
        contactPhone = phone;
        contactEmail = email;
      }

      public override string ToString() => $"{contactName} - {contactPhone} - {contactEmail}";
    }

    static void Main(string[] args)
    {
      List<Contact> ContactsList = new List<Contact>();

      bool isDone = false;
      while (!isDone)
      {
        Console.Clear();
        Console.WriteLine("*** Welcome to Contact App ***");
        Console.WriteLine("\n1) View Contacts\n2) Add Contacts\n3) Delete Contacts\n4) Search For Contact\n5) Exit");
        Arrow();

        if (int.TryParse(Console.ReadLine(), out int userOption))
        {
          switch (userOption)
          {
            case 1:
              ShowContacts(ContactsList);
              break;
            case 2:
              AddContact(ContactsList);
              break;
            case 3:
              DeleteContact(ContactsList);
              break;
            case 4:
              SearchContact(ContactsList);
              break;
            case 5:
              isDone = true;
              Console.WriteLine("Bye Bye!");
              Environment.Exit(0);
              break;
            default:
              Console.WriteLine("Please Enter Fucking Right Number.");
              break;
          }
        }
        else Console.WriteLine("Please Enter Fucking Right Number.");

        if (!isDone)
        {
          Console.WriteLine("\nPress Enter To Continue...");
          Console.ReadLine();
        }
      }
    }

    static void Arrow() => Console.Write("=> ");

    static void ShowContacts(List<Contact> ContactsList)
    {
      if (ContactsList.Count == 0)
      {
        Console.WriteLine("There is nothing to show!");
        return;
      }

      Console.WriteLine("\nvvvvvvvvvvvvvvvvvvvv");
      for (int i = 0; i < ContactsList.Count; i++)
      {
        Console.WriteLine($"{i}) {ContactsList[i]}");
      }
      Console.WriteLine("۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸");
    }

    static void AddContact(List<Contact> ContactsList)
    {
      Console.WriteLine("Enter contat name: ");
      Arrow();
      string newConName = Console.ReadLine();

      Console.WriteLine("Enter contat phone: ");
      Arrow();
      string newConPhone = Console.ReadLine();

      Console.WriteLine("Enter contat email: ");
      Arrow();
      string newConEmail = Console.ReadLine();

      Contact newContact = new Contact(newConName, newConPhone, newConEmail);
      ContactsList.Add(newContact);

      Console.WriteLine("\nThe contact added succussfuly!");
    }

    static void SearchTemplate(string type, List<Contact> theFunc)
    {
      Console.WriteLine($"Enter {type}: ");
      Arrow();
      string contactName = Console.ReadLine().ToLower();

      var foundContact = theFunc.FindAll(c => c.contactName.ToLower().Contains(contactName));

      switch (type)
      {
        case "Name":
          foundContact = theFunc.FindAll(c => c.contactName.ToLower().Contains(contactName));
          break;
        case "Phone":
          foundContact = theFunc.FindAll(c => c.contactPhone.ToLower().Contains(contactName));
          break;
        case "Email":
          foundContact = theFunc.FindAll(c => c.contactEmail.ToLower().Contains(contactName));
          break;
      }

      if (foundContact.Count == 0)
      {
        Console.WriteLine("Contact Not Found");
      }

      foreach (var contact in foundContact)
      {
        Console.WriteLine(contact);
      }
    }

    static void SearchContact(List<Contact> ContactsList)
    {
      if (ContactsList.Count == 0) return;
      // ShowContacts(ContactsList);

      Console.WriteLine("\nIn wich way you want to search for your contact?");
      Console.WriteLine("1) search by Name\n2) search by Phone number\n3) search by Email");
      Arrow();
      byte userOption = Convert.ToByte(Console.ReadLine());

      switch (userOption)
      {
        case 1:
          SearchTemplate("Name", ContactsList);
          break;
        case 2:
          SearchTemplate("Phone", ContactsList);
          break;
        case 3:
          SearchTemplate("Email", ContactsList);
          break;
        default:
          Console.WriteLine("Please Enter Fucking Right Number.");
          break;
      }
    }

    static void DeleteContact(List<Contact> ContactsList)
    {
      ShowContacts(ContactsList);
      Console.WriteLine("Enter Contact \"id\" for delete.");
      Arrow();
      int conID = Convert.ToInt32(Console.ReadLine());
      ContactsList.RemoveAt(conID);

      Console.WriteLine("Contacts Deleted succussfuly!");
    }
  }
}
