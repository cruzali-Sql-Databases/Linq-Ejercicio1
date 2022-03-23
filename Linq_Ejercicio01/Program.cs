﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tipos anonimos
            var producto = new { Nombre = "Laptop", Precio = 12500 };

            //ControlEmpresasEmpleados ce = new ControlEmpresasEmpleados();
            ////ce.getCEO();
            ////ce.getEmpleadosOrdenados();
            //ce.getEmpleadosPildoras();

            ControlProductOrder fabricaProductOrder = new ControlProductOrder();
            //fabricaProductOrder.getInnerJoin();
            //fabricaProductOrder.getLeftJoin();
            //fabricaProductOrder.getCrossJoin();
            //fabricaProductOrder.getGroupJoin();

            Console.WriteLine("getOrderByProduct");
            fabricaProductOrder.getOrderByProduct();

            //fabricaProductOrder.getOrderDetailsExtencionMethods();

            ControlEmployeeAddress cEmployeeAddress = new ControlEmployeeAddress();
            //cEmployeeAddress.joinEmployeeAddressMethodSyntax();
            //cEmployeeAddress.joinEmployeeAddressQuerySyntax();


            ControlEmployeeAddressDepartament cEmployeeAdDep = new ControlEmployeeAddressDepartament();
            cEmployeeAdDep.joinQuerySyntax();
            cEmployeeAdDep.joinMethodSyntax();





            //int[] valoresNumericos = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Console.WriteLine("Numeros Pares: ");

            ////List<int> numerosPares = new List<int>();

            ////foreach (int i in valoresNumericos)
            ////{
            ////    if (i % 2 == 0)
            ////    {
            ////        numerosPares.Add(i);
            ////    }
            ////}


            //IEnumerable<int> numerosPares = from par in valoresNumericos 
            //                                where par % 2 == 0 
            //                                select par;

            //foreach (int i in numerosPares)
            //{
            //    Console.WriteLine(i);
            //}

        }


        /*
         * ****************************************************************************************************************************
         */
        class ControlEmpresasEmpleados
        {

            public ControlEmpresasEmpleados()
            {
                listaEmpresas = new List<Empresa>();
                listaEmpleados = new List<Empleado>();

                listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Google" });
                listaEmpresas.Add(new Empresa { Id = 2, Nombre = "Pildoras" });
                listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Sergey", Cargo = "CEO", EmpresaId = 1, Salario = 15000 });
                listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Juan", Cargo = "CEO", EmpresaId = 2, Salario = 15000 });
                listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Larry", Cargo = "Co-CEO", EmpresaId = 1, Salario = 15000 });
                listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Irina", Cargo = "Co-CEO", EmpresaId = 2, Salario = 15000 });

            }

            public void getCEO()
            {
                IEnumerable<Empleado> ceos = from empleado in listaEmpleados where empleado.Cargo == "CEO" select empleado;

                foreach (Empleado empleado1 in ceos)
                {
                    empleado1.getDatosEmpleado();

                }
            }

            public void getEmpleadosOrdenados()
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby empleado.Nombre ascending select empleado;

                foreach (Empleado empleado1 in empleados)
                {
                    empleado1.getDatosEmpleado();
                }
            }


            public void getEmpleadosPildoras()
            {
                IEnumerable<Empleado> empleados = from empleado in listaEmpleados
                                                  join empresa in listaEmpresas
                                                  on empleado.EmpresaId equals empresa.Id
                                                  where empresa.Nombre == "Pildoras"
                                                  select empleado;

                foreach (Empleado empleado1 in empleados)
                {
                    empleado1.getDatosEmpleado();
                }
            }

            public List<Empresa> listaEmpresas;
            public List<Empleado> listaEmpleados;


        }

        class Empresa
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public void getDatosEmpresa()
            {
                Console.WriteLine("Empresa {0} con Id {1} ", Nombre, Id);
            }
        }

        class Empleado
        {
            public int Id { get; set; }

            public string Nombre { get; set; }

            public string Cargo { get; set; }

            public double Salario { get; set; }

            public int EmpresaId { get; set; }

            public void getDatosEmpleado()
            {
                Console.WriteLine("Empleado {0} con Id {1}, cargo {2}, con salario {3} " +
                    "perteneciente a la empresa {4} ", Nombre, Id, Cargo, Salario, EmpresaId);
            }
        }



        /*
         * ****************************************************************************************************************************
         */

        class ControlProductOrder
        {
            public List<Product> Products;
            public List<Order> Orders;

            public ControlProductOrder()
            {
                Products = new List<Product>();
                Orders = new List<Order>();

                Products.Add(new Product { ProductId = 1, Name = "Book nr 1", Price = 11 });
                Products.Add(new Product { ProductId = 2, Name = "Book nr 2", Price = 12 });
                Products.Add(new Product { ProductId = 3, Name = "Book nr 3", Price = 13 });
                Products.Add(new Product { ProductId = 4, Name = "Book nr 4", Price = 14 });
                Products.Add(new Product { ProductId = 5, Name = "Book nr 5", Price = 15 });

                Orders.Add(new Order { OrderId = 1, ProductId = 1, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 2, ProductId = 2, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 3, ProductId = 1, Movimiento = "Baja" });
                Orders.Add(new Order { OrderId = 4, ProductId = 3, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 5, ProductId = null, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 6, ProductId = 1, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 7, ProductId = null, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 8, ProductId = 3, Movimiento = "Baja" });
                Orders.Add(new Order { OrderId = 9, ProductId = 1, Movimiento = "Baja" });
                Orders.Add(new Order { OrderId = 10, ProductId = 5, Movimiento = "Alta" });
                Orders.Add(new Order { OrderId = 11, ProductId = null, Movimiento = "Alta" });
            }


            public void getInnerJoin()
            {
                var joined = (from p in Products
                              join o in Orders on p.ProductId equals o.ProductId
                              select new
                              {
                                  o.OrderId,
                                  p.ProductId,
                                  p.Name
                              });
                Console.WriteLine("Inner Join: \n");
                Console.WriteLine(String.Join(",\n", joined));

            }


            public void getLeftJoin()
            {
                //var leftJoin = (from p in Products
                //                join o in Orders on p.ProductId equals o.ProductId into g
                //                from lj in g.DefaultIfEmpty()
                //                select new
                //                {
                //                    OrderId = (int?)lj.OrderId,
                //                    p.ProductId,
                //                    p.Name
                //                });

                var joined = (from p in Products
                              join o in Orders on p.ProductId equals o.ProductId into g
                              from lj in g.DefaultIfEmpty()
                              select new
                              {
                                  //For the empty records in lj, OrderId would be NULL
                                  OrderId = (int?)lj.OrderId,
                                  p.ProductId,
                                  p.Name
                              }).ToList();

                Console.WriteLine("Left Join: \n");
                Console.WriteLine(String.Join(",\n", joined));
            }
            public void getCrossJoin()
            {
                //var crossJoin = (from p in Products
                //                 from o in Orders
                //                 select new
                //                 {
                //                     o.OrderId,
                //                     p.ProductId,
                //                     p.Name
                //                 });

                var joined = (from p in Products
                              from o in Orders
                              select new
                              {
                                  o.OrderId,
                                  p.ProductId,
                                  p.Name
                              }).ToList();

                Console.WriteLine("Cross Join: \n");
                Console.WriteLine(String.Join(",\n", joined));
            }

            public void getGroupJoin()
            {
                var joined = (from p in Products
                              join o in Orders on p.ProductId equals o.ProductId
                              into t
                              select new
                              {
                                  p.ProductId,
                                  p.Name,
                                  Orders = t
                              });

                Console.WriteLine("Group Join: \n");
                Console.WriteLine(String.Join(",\n", joined));
            }

            public void getOrderByProduct()
            {
                var details = from o in Orders
                              orderby o.OrderId
                              join p in Products
                              on o.ProductId equals p.ProductId
                              into G
                              select new
                              {
                                  Orden = o.OrderId,
                                  Producto = from p2
                                             in G
                                             orderby p2.ProductId
                                             select p2

                              };

                

                foreach (var G in details)
                {
                    Console.WriteLine(G.Orden);

                    foreach (var product in G.Producto)
                    {

                        Console.WriteLine("* {0}",
                            product.Price);
                    }
                }


                Console.WriteLine("Ordenes por Prodcuto: \n");

                //Console.WriteLine(String.Join(",\n", details));


            }

            public void getOrderDetailsExtencionMethods()
            {
                var productLastMovement = Orders.GroupBy(a => a.ProductId)
                                            .Select(g => g.OrderByDescending(i => i.OrderId)
                                            .FirstOrDefault());

                var products = Products.GroupBy(p => p.ProductId);

                var ordenes = Orders.GroupBy(a => a.Movimiento);

                //foreach (var producto in productLastMovement)
                //{
                //    Console.WriteLine("Producto: ==== {0} ====", producto.ProductId);

                //    foreach (var order in producto)
                //    {
                //        Console.WriteLine("Orden: * {0}, Movimiento: {1}", order.OrderId, order.Movimiento);
                //    }
                //}


                //var pr = Products.Select(Orders.Where(p => p.ProductId));
            }


        }


        class Product
        {
            public int ProductId { get; set; }

            public string Name { get; set; }

            public double Price { get; set; }

            public void getDatosProduct()
            {
                Console.WriteLine("ProductId: {0}, Name: {1}, Price: {2}", ProductId, Name, Price);
            }
        }

        class Order
        {
            public int OrderId { get; set; }
            public int? ProductId { get; set; }

            public string Movimiento { get; set; }

            public void getDatosOrder()
            {
                Console.WriteLine("OrderId: {0}, ProductId: {1}", OrderId, ProductId);
            }
        }


        /*          
          * ****************************************************************************************************************************
        */

        class ControlEmployeeAddress
        {
            public ControlEmployeeAddress()
            {

            }

            public void joinEmployeeAddressMethodSyntax()
            {
                // Method Syntax
                var JoinUsingMS = Employee.GetAllEmployees() //Outer Data Source
                                          .Join(
                                              Address.GetAllAddresses(),  //Inner Data Source
                                              employee => employee.AddressId, //Inner Key Selector
                                              address => address.ID, //Outer Key selector
                                              (employee, address) => new //Projecting the data into a result set
                                              {
                                                  EmployeeName = employee.Name,
                                                  AddressLine = address.AddressLine
                                              }).ToList();
                foreach (var employee in JoinUsingMS)
                {
                    Console.WriteLine("Name: {0} \t\t Address: {1}", employee.EmployeeName, employee.AddressLine);
                }
                Console.ReadLine();
            }

            public void joinEmployeeAddressQuerySyntax()
            {
                var JoinUsingQS = (from e in Employee.GetAllEmployees()
                                   join a in Address.GetAllAddresses()
                                   on e.AddressId equals a.ID
                                   select new
                                   {
                                       eName = e.Name,
                                       eAddress = a.AddressLine
                                   }).ToList();

                foreach (var employee in JoinUsingQS)
                {
                    Console.WriteLine("Name: {0}. \t Address: {1}", employee.eName, employee.eAddress);
                }
            }


        }


        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int AddressId { get; set; }
            public static List<Employee> GetAllEmployees()
            {
                return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1 },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2 },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3 },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4 },
                new Employee { ID = 5, Name = "Hina", AddressId = 5 },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6 },
                new Employee { ID = 7, Name = "Happy", AddressId = 7},
                new Employee { ID = 8, Name = "Tarun", AddressId = 8 },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9 },
                new Employee { ID = 10, Name = "Raja", AddressId = 10},
                new Employee { ID = 11, Name = "Sudhanshu", AddressId = 11}
            };
            }
        }

        public class Address
        {
            public int ID { get; set; }
            public string AddressLine { get; set; }
            public static List<Address> GetAllAddresses()
            {
                return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1"},
                new Address { ID = 2, AddressLine = "AddressLine2"},
                new Address { ID = 3, AddressLine = "AddressLine3"},
                new Address { ID = 4, AddressLine = "AddressLine4"},
                new Address { ID = 5, AddressLine = "AddressLine5"},
                new Address { ID = 9, AddressLine = "AddressLine9"},
                new Address { ID = 10, AddressLine = "AddressLine10"},
                new Address { ID = 11, AddressLine = "AddressLine11"},
                new Address { ID = 12, AddressLine = "AddressLine12"}
            };
            }
        }


        /*          
          * ****************************************************************************************************************************
        */


        class ControlEmployeeAddressDepartament
        {
            public void joinQuerySyntax()
            {
                // data source 1
                var joins = (from e in Employee2.GetAllEmployees()
                                 // join data source 2
                             join a in Address2.GetAllAddresses()
                             on e.AddressId equals a.ID
                             // join data source 3
                             join d in Department2.GetAllDepartments()
                             on e.DepartmentId equals d.ID
                             select new
                             {
                                 ID = e.ID,
                                 Name = e.Name,
                                 Department = d.Name,
                                 Address = a.AddressLine
                             }).ToList();

                foreach (var employee in joins)
                {
                    Console.WriteLine("ID: {0}, \t Name {1}, \t Address: {2}, \t Department: {3}", 
                        employee.ID, employee.Name, employee.Address, employee.Department);
                }
            }

            public void joinMethodSyntax()
            {
                // Data Source 1
                var joinMethodSyntax = Employee2.GetAllEmployees()
                    // Join Data Source 2
                    .Join(Address2.GetAllAddresses(),
                        // Outer Key Selector - 'on x.xid equals y.id'
                        // empLevel1 - 
                        e => e.AddressId,
                        // Inner Key Selector
                        // addLevel1
                        a => a.ID,
                        (e, a) => new { e, a }
                    )
                    .Join(Department2.GetAllDepartments(),
                        // empLevel2
                        e => e.e.DepartmentId,
                        // addLevel1
                        d => d.ID,
                        (e, d) => new { e, d }
                    )
                    .Select(e => new
                    {
                        ID = e.e.e.ID,
                        Name = e.e.e.Name,
                        Address = e.e.a.AddressLine,
                        Department = e.d.Name
                    }).ToList();

                foreach (var employee in joinMethodSyntax)
                {
                    Console.WriteLine("ID: {0}, Name {1}, Address {2}, Department {3}",
                        employee.ID, employee.Name, employee.Address, employee.Department);
                }

            }
        }
        public class Employee2
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int AddressId { get; set; }
            public int DepartmentId { get; set; }
            public static List<Employee2> GetAllEmployees()
            {
                return new List<Employee2>()
            {
                new Employee2 { ID = 1, Name = "Preety", AddressId = 1, DepartmentId = 10    },
                new Employee2 { ID = 2, Name = "Priyanka", AddressId = 2, DepartmentId =20   },
                new Employee2 { ID = 3, Name = "Anurag", AddressId = 3, DepartmentId = 30    },
                new Employee2 { ID = 4, Name = "Pranaya", AddressId = 4, DepartmentId = 0    },
                new Employee2 { ID = 5, Name = "Hina", AddressId = 5, DepartmentId = 0       },
                new Employee2 { ID = 6, Name = "Sambit", AddressId = 6, DepartmentId = 0     },
                new Employee2 { ID = 7, Name = "Happy", AddressId = 7, DepartmentId = 0      },
                new Employee2 { ID = 8, Name = "Tarun", AddressId = 8, DepartmentId = 0      },
                new Employee2 { ID = 9, Name = "Santosh", AddressId = 9, DepartmentId = 10   },
                new Employee2 { ID = 10, Name = "Raja", AddressId = 10, DepartmentId = 20    },
                new Employee2 { ID = 11, Name = "Ramesh", AddressId = 11, DepartmentId = 30  }
            };
            }
        }
        public class Address2
        {
            public int ID { get; set; }
            public string AddressLine { get; set; }
            public static List<Address2> GetAllAddresses()
            {
                return new List<Address2>()
            {
                new Address2 { ID = 1, AddressLine = "AddressLine1"      },
                new Address2 { ID = 2, AddressLine = "AddressLine2"      },
                new Address2 { ID = 3, AddressLine = "AddressLine3"      },
                new Address2 { ID = 4, AddressLine = "AddressLine4"      },
                new Address2 { ID = 5, AddressLine = "AddressLine5"      },
                new Address2 { ID = 9, AddressLine = "AddressLine9"      },
                new Address2 { ID = 10, AddressLine = "AddressLine10"    },
                new Address2 { ID = 11, AddressLine = "AddressLine11"    },
            };
            }
        }
        public class Department2
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public static List<Department2> GetAllDepartments()
            {
                return new List<Department2>()
                {
                    new Department2 { ID = 10, Name = "IT"       },
                    new Department2 { ID = 20, Name = "HR"       },
                    new Department2 { ID = 30, Name = "Payroll"  },
                };
            }
        }


        /*          
  * ****************************************************************************************************************************
*/

        public class Employee3
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int DepartmentId { get; set; }
            public static List<Employee3> GetAllEmployees()
            {
                return new List<Employee3>()
            {
                new Employee3 { ID = 1, Name = "Preety", DepartmentId = 10},
                new Employee3 { ID = 2, Name = "Priyanka", DepartmentId =20},
                new Employee3 { ID = 3, Name = "Anurag", DepartmentId = 30},
                new Employee3 { ID = 4, Name = "Pranaya", DepartmentId = 30},
                new Employee3 { ID = 5, Name = "Hina", DepartmentId = 20},
                new Employee3 { ID = 6, Name = "Sambit", DepartmentId = 10},
                new Employee3 { ID = 7, Name = "Happy", DepartmentId = 10},
                new Employee3 { ID = 8, Name = "Tarun", DepartmentId = 0},
                new Employee3 { ID = 9, Name = "Santosh", DepartmentId = 10},
                new Employee3 { ID = 10, Name = "Raja", DepartmentId = 20},
                new Employee3 { ID = 11, Name = "Ramesh", DepartmentId = 30}
            };
            }
        }

        public class Department3
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public static List<Department3> GetAllDepartments()
            {
                return new List<Department3>()
                {
                    new Department3 { ID = 10, Name = "IT"},
                    new Department3 { ID = 20, Name = "HR"},
                    new Department3 { ID = 30, Name = "Sales"  },
                };
            }
        }


    }
}
