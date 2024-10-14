namespace InheritanceApp
{
    internal class Program
    {

        /* First Aspect
         * Constructors are special methods in a
           class that are called when an instance of
           the class is created. In the context of
           inheritance, constructors of the base
           class are called before the constructors of
           the derived class. This ensures that the
           base class is properly initialized before any
           additional initialization in the derived class
           takes place.

        Why is it important?

        Proper Initialization:
        Ensures that all fields and properties of
        the base class are correctly set up before
        any operations of the derived class can
        take place.
        
        This means that when creating an object
        of a derived class, the constructor of the
        base class runs first to initialize its
        members.


        Second Aspect:
        Consistent State:-
        Maintains a consistent and valid state
        across the object hierarchy.
        
        This ensures that both the base class and
        the derived class remain in a valid state
        throughout the object's lifetime. By running
        the base class constructor first, we ensure
        that any dependencies or required initial
        states are established.


        Third Aspect:
        Reuse of Initialization Code:
        Avoids duplication of initialization code by
        reusing the base class constructor.

        This means that common setup tasks
        needed by both the base and derived
        classes are handled once in the base class
        constructor. The derived class does not
        need to repeat this setup, making the code
        cleaner and reducing errors.


        #Why Constructor Inheritance is Usful

         1. Ensuring Base Class Initialization:
            The base class Person has fields Name and
            Age that must be initialized. By calling
            base(name, age), we ensure that these
            fields are set up before the Employee
            constructor continues with its own
            initialization.
        
        2. Avoiding Code Duplication:
            The initialization logic for Name and Age is
            centralized in the Person class. If these
            fields were initialized separately in every
            derived class, it would lead to code
            duplication and potential errors if the
            initialization logic needed to be changed.

        3. Maintaining Invariance:
            By establishing and maintaining class
            invariants in the constructor, you ensure
            that the object remains in a valid and
            expected state, adhering to all necessary
            conditions throughout its existence.
        
        4. Extensibility:
            Derived classes can extend the
            initialization process by adding their own
            parameters and initializing their own
            fields, while still leveraging the base class
            constructor for shared fields.

        ------------------
        sealed Keyword -> Why we would use it?
        
        public sealed class Employee : Person 
        {
            ~~~~~~~
        }
            
        1. Design Integrity:
            Sealing a class ensures that its design is final
            and cannot be altered through inheritance.
            This is crucial when you want to enforce
            specific behavior and prevent modifications
            that could compromise the design.
            
        - Example: In the banking application, the
                   SavingsAccount class has specific withdrawal
                   rules that should not be overridden by any
                   further derived class.

        2. Security:
             Preventing further inheritance can enhance
             security by avoiding unintended behavior or misuse.
             By sealing a class, you ensure that critical
             functionality remains consistent and secure.
             
        - Example: By sealing the SavingsAccount
                   class, you ensure that no unauthorized or
                   accidental changes can be made to how
                   withdrawals are processed, maintaining the
                   security of the account operations.

        3. Performance:
                Sealed classes can sometimes lead to
                performance optimizations.
                The runtime doesn't need to check for method
                overrides in derived classes, leading to faster
                execution.

        - Example: In high-performance applications,
                   sealing classes not meant to be extended can
                   reduce the overhead of virtual method calls,
                   providing slight performance gains.

        4. Preventing Misuse:
                Sealing a class prevents it from being used
                as a base class, which can be important if the
                class was not designed with extensibility in mind.
                Avoiding potential misuse or errors from improper extensions.
                 
        - Example: If SavingsAccount is not meant to
                   be extended with additional account types or
                   behaviors, sealing it ensures developers do
                   not mistakenly try to extend it.

        */



        //Ex4 -> Constructor Inheritance 1 - Base Keyword with Constructors
        //and How Properties are.
        public class Person
        {
            //prop
            public string Name { get; private set; }
            public int Age { get; private set; }


            //constructor
            public Person(string name, int age)
            {
                Name = name;
                Age = age;  

                Console.WriteLine("Person constructor called");
            }

            //method
            public void DisplayPersonInfo()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}");
            }
        }

        //drived class
        public class Employee : Person
        {
            public string JobTitle { get; private set; }
            public int EmployeeID { get; private set; }

            //constructor inheritance using base
            public Employee(string name, int age, string jobTitle, int employeId) : base(name, age)
            {
                JobTitle = jobTitle;
                EmployeeID = employeId;
                Console.WriteLine("Employee (derived class) constructor called");
            }
            public void DisplayEmployeeinfo() 
            {
                DisplayPersonInfo(); // call method from base class
                Console.WriteLine($"Job Title: {JobTitle}, Employee ID: {EmployeeID}");
            }
        }

        //===============================================
        //Ex5 -> Constructor Inheritance with Multiple Derived Classes

        public class Manager : Employee
        {

            public int TeamSize {  get; private set; }

            public Manager(string name, int age, string jobTitle, int employeId, int teamsize) 
                : base(name, age, jobTitle, employeId)
            {
                TeamSize = teamsize;
            }

            public void DisplayManagerinfo()
            {
                DisplayEmployeeinfo(); // call method from base class
                Console.WriteLine($"Team Size: {TeamSize}");
            }
        }

        //=========================

        //#Ex2 -> Access modifiers Example
        class BaseClass
        {
           
            public int publicField;
            protected int protectedField;
            private int privateField;

            public void ShowFields()
            {
                Console.WriteLine($"Public: {publicField}, Protected: {protectedField}, Private: {privateField}");
            }
        }

        class DerivedClass : BaseClass
        {
            public void AccessFields()
            {
                publicField = 1;
                //avilable to every Child Class
                protectedField = 2;
                //cant Access private field
                //would be only accessble in its class
            }
        }



        static void Main(string[] args)
        {

            //Ex1 & Ex2
            /*Dog myDog = new Dog();
            *//*myDog.Bark();
            myDog.Eat();*//*

            myDog.MakeSound();

            Cat myCat = new Cat();
            myCat.MakeSound()*/;

            //====================================
            //#Ex2 Access modifiers 
           /* BaseClass myBaseClass = new BaseClass();
            myBaseClass.ShowFields();

            DerivedClass myDerivedClass = new DerivedClass();
            myDerivedClass.AccessFields();
            myDerivedClass.ShowFields();*/

            //==================================================
            //Ex4 Constructor Inheritance 1
            Employee osama = new Employee("Osama", 26, "ASP.Net Developer", 1);
            osama.DisplayEmployeeinfo();


            //==========================================
            //Ex5 Constructor Inheritance with Multiple Derived Classes

            Manager carl = new Manager("Carl", 45, "Manager", 2, 7);
            carl.DisplayManagerinfo();


            Console.ReadKey();
        }
    }

    //#Ex1 

    //Base Class(Parent Class Or Superclass)
    //The class those members are inherited
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }


        //Ex3 -> Override using virtual
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound.");
        }

    }

    //Dog -> First type: Single inheritance 
    //Derived Class(Child Class or Subclass):
    //The Class that inherits the members of the base class
    class Dog : Animal 
    { 
        public override void MakeSound()
        {
            //to ensure nothing is misssing or casing issues
            //in the drived class -> base.MakeSound();

            base.MakeSound();
            Console.WriteLine("Barking....");
        }
    }

    //Cat -> Third type: Hierarchical inheritance
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Cat is meowing");
        }
    }


    //Collie -> Second type: Multilevel Inheritance 
    class Collie : Dog
    {
        public void GoingNuts()
        {
            Console.WriteLine("Collie going nuts!");
        }
    }


    /*Note of Ex1:-
     
     Forth type: Multiple Inheritance:
                
        - Not directly supported in C# for classes, but supported for interfaces. 
        - You can achieve something similar through interface implementation or 
          by using composition.
     */


    /*Note of Ex3 override
    
    Now why would this be useful?
        - Well, the thing is, sometimes you just really want to use the same 
          method name with a derived class
          because you want to do something similar or its own implementation, 
          so to speak, for each given class.
          And in order to achieve that, you need to override it. 

    overriding
        this virtual keyword is part of polymorphism, which is the third part 
        of OOP.

    - A technique to redefine a base class method in a derived class.

     */
}
