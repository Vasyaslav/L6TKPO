using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary
{
    public abstract class Observer
    {
        public abstract void Update(string newData);
    }

    public abstract class Observable
    {
        protected List<Observer> _observers = new List<Observer>();
        
        public void AddObserver(Observer observer)
        {
            _observers.Add(observer);
        }
        public void NotifyUpdate(string newData)
        {
            int size = _observers.Count; 
            for (int i = 0; i < size; i++)
            {
                _observers[i].Update(newData);
            }
        }
    }

    public abstract class State
    {
        public string name { get; protected set; }
        public abstract string Handle(ElevatorModel e);
    }

    public class Peace:  State
	{
	public Peace()
        {
            name = "В покое";
        }
    public override string Handle(ElevatorModel e)
        {
            if (e.next_floor == e.floor)
            {
                return "Текущий этаж совпадает со следующим, лифт остаётся в покое\n";
            }
            else if (e.mass > e.max_mass && e.powerShortageChance > 50)
            {
                return e.SetState(new Breakdown(),
                    "Авария: лифт перегружен, высокий риск отключения питания");
            }
            else if (e.mass > e.max_mass)
            {
                return e.SetState(new Overloaded(),
                    "Лифт перегружен, слишком много людей");
            }
            else if (e.powerShortageChance > 50)
            {
                return e.SetState(new PowerShortage(),
                    "Слишком высокий риск отключения питания");
            }
            return e.SetState(new Moving(),
                "Всё в порядке, нажмите кнопку ещё раз, чтобы доехать до нужного этажа");
        }
	}

    public class Moving: State
    {
        public Moving()
        {
            name = "В движении";
        }
        public override string Handle(ElevatorModel e)
        {
            if (e.powerShortageChance > 50)
            {
                e.SetState(new PowerShortage(), "Слишком высокий риск отключения питания");
            }
            e.ChangeFloor();
            return e.SetState(new Peace(), "Лифт успешно доехал");
        }
    }

    public class Overloaded: State
    {
        public Overloaded()
        {
            name = "Лифт перегружен";
        }
        public override string Handle(ElevatorModel e)
        {
            if (e.mass > e.max_mass && e.powerShortageChance > 50)
            {
                return e.SetState(new Breakdown(),
                    "Авария: лифт перегружен, высокий риск отключения питания");
            }
            else if (e.mass > e.max_mass)
            {
                return "Лифт перегружен, движение невозможно\n";
            }
            else if (e.powerShortageChance > 50)
            {
                e.SetState(new PowerShortage(), "Слишком высокий риск отключения питания");
            }
            return e.SetState(new Peace(), "Лифт больше не перегружен");
        }
    }

    public class PowerShortage: State
    {
        public PowerShortage()
        {
            name = "Нет питания";
        }
        public override string Handle(ElevatorModel e)
        {
            if (e.powerShortageChance > 20)
            {
                return "Убавьте риск отключения питания ниже 20%\n";
            }
            return e.SetState(new Peace(), "Риск отключения питания стал ниже 20%");
        }
    }

    public class Breakdown: State
    {
        public Breakdown()
        {
            name = "Аварийное состояние";
        }
        public override string Handle(ElevatorModel e)
        {
            if (e.mass == 0 && e.powerShortageChance < 20)
            {
                return e.SetState(new Peace(),
                    "Риск отключения меньше 20%, выведены люди");
            }
            return "Уменьшите риск отключения питания ниже 20% и выведите всех людей из лифта\n";
        }
    }

    public class ElevatorModel: Observable
    {
        public int floor { get; private set; }
        public int next_floor { get; private set; }
        public int max_mass { get; private set; }
        public int mass { get; private set; }
        public int powerShortageChance { get; private set; }
        public State state { get; private set; }
        public ElevatorModel()
        {
            floor = 1;
            next_floor = 1;
            max_mass = 250;
            mass = 0;
            powerShortageChance = 5;
            state = new Peace();
        }

        public void ChangeFloor()
        {
            floor = next_floor;
        }

        public void ChangeNextFloor(int nFloor)
        {
            next_floor = nFloor;
        }

        public void Load()
        {
            mass += 70;
        }

        public void Unload()
        {
            mass -= 70;
        }

        public void ChangePower(int p)
        {
            powerShortageChance = p;
        }

        public string Move()
        {
            string moveResult = state.Handle(this);
            return $"Текущий этаж = {floor}\nТекущая масса = {mass}\nТекущая вероятность отключения электроэнергии = {powerShortageChance}%\nПопытка поехать: {moveResult}\n";
        }

        public string Info()
        {
            return $"Текущий этаж = {floor}\nТекущая масса = {mass}\nТекущая вероятность отключения электроэнергии = {powerShortageChance}%\nТекущее состояние: {state.name}\n";
        }

        public string Info(string str)
        {
            return $"Текущий этаж = {floor}\nТекущая масса = {mass}\nТекущая вероятность отключения электроэнергии = {powerShortageChance}%\nТекущее состояние: {str}\n";
        }

        public string SetState(State s, string message)
        {
            state = s;
            return $"состояние изменено: {s.name}, причина: {message}\n";
        }
    }
}
