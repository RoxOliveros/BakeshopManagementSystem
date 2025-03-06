namespace BakeshopManagementSys
{
    internal class Program
    {
        static List<string> menu = new List<string>(); // Stores products

        static void Main(string[] args)

        {

            string username = "admin";
            string pin = "1234";
            string usernameInput;
            string pinInput;

            Console.WriteLine("== LOGIN ==");

            do
            {
                Console.Write("Enter Username: ");
                usernameInput = Console.ReadLine();

                Console.Write("Enter Pin: ");
                pinInput = Console.ReadLine();

                if (usernameInput != username && pinInput != pin)
                {
                    Console.WriteLine("Invalid username or pin. Please try again :p");

                }
                else
                {
                    int userAction;
                    do
                    {
                        Console.WriteLine("\n == WELCOME TO XANNE'S BAKESHOP == ");

                        string[] actions = new string[] { "[1] Add Product", "[2] Delete Product",
                        "[3] Search Product", "[4] View Menu",  "[5] Exit"  };

                        Console.WriteLine("Choose an Action");

                        foreach (var action in actions)
                        {
                            Console.WriteLine(action);
                        }
                        Console.Write("Enter Action: ");
                        userAction = Convert.ToInt16(Console.ReadLine());

                        switch (userAction)
                        {
                            case 1:
                                AddProduct();
                                break;
                            case 2:
                                DeleteProduct();
                                break;
                            case 3:
                                SearchProduct();
                                break;
                            case 4:
                                ViewMenu();
                                break;
                            case 5:
                                Console.WriteLine("Exiting program. Thank you!");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please select a number between 1-5.");
                                break;
                        }

                    } while (userAction != 5);


                }

            } while (usernameInput != username && pinInput != pin); 
            
            }

        static void AddProduct()
        {

            Console.Write("Enter a product: ");
            string product = Console.ReadLine();


            if (!string.IsNullOrEmpty(product))
            {
                menu.Add(product);
                Console.WriteLine($"'{product}' has been added to the menu.");
            }
            else
            {
                Console.WriteLine("Please enter a product");
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Enter product to delete: ");
            string productDelete = Console.ReadLine();

            if (!string.IsNullOrEmpty(productDelete))
            {
                if (menu.Contains(productDelete))
                {
                    menu.Remove(productDelete);
                    Console.WriteLine($"'{productDelete}' has been removed from the menu.");
                }
                else
                {
                    Console.WriteLine($"'{productDelete}' was not found in the menu.");
                }
            }
            else {
                Console.WriteLine("Please enter a product to delete...");
            }
        }

        static void SearchProduct()
        {
            Console.Write("Enter product name to search: ");
            string searchItem = Console.ReadLine();

            if (menu.Contains(searchItem))
            {
                Console.WriteLine($"'{searchItem}' is available in the menu.");
            }
            else
            {
                Console.WriteLine($"'{searchItem}' is not in the menu.");
            }
        }

        static void ViewMenu()
        {
            Console.WriteLine("\n===== MENU ITEMS =====");
            if (menu.Count == 0)
            {
                Console.WriteLine("No products in the menu.");
            }
            else
            {
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i]}");
                }
            }
        }
    }
}
