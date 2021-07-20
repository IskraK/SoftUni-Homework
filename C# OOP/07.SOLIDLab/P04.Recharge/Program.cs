namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Worker worker1 = new Employee("123");
            worker1.Work(2);

            Worker worker2 = new Robot("111", 1);
            worker2.Work(2);

            Employee employee = new Employee("321");
            employee.Sleep();
            employee.Work(3);

            Robot robot = new Robot("222", 2);
            robot.Work(3);
            Console.WriteLine(robot.Capacity);
            Console.WriteLine(robot.CurrentPower);
            robot.Recharge();
            Console.WriteLine(robot.Capacity);
            Console.WriteLine(robot.CurrentPower);
            robot.Work(1);
            Console.WriteLine(robot.Capacity);
            Console.WriteLine(robot.CurrentPower);
            robot.Work(4);
            Console.WriteLine(robot.Capacity);
            Console.WriteLine(robot.CurrentPower);
        }
    }
}
