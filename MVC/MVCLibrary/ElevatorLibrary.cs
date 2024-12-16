using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary
{
    abstract class Observer
    {
        public abstract void Update();
    }

    abstract class Observable
    {
        protected List<Observer> _observers = new List<Observer>();
        
        public void AddObserver(Observer observer)
        {
            _observers.Add(observer);
        }
        public void NotifyUpdate()
        {
            int size = _observers.Count; 
            for (int i = 0; i < size; i++)
            {
                _observers[i].Update();
            }
        }
    }

    abstract class State
    {
        public string name { get; protected set; }
        public abstract string Handle(ElevatorModel e);
    }

    class Peace:  State
	{
	public Peace()
        {
            name = "В покое";
        }
    public override string Handle(ElevatorModel e)
        {
            return "12";
        }
	}

    class Moving: State
    {
        public Moving()
        {
            name = "Движение";
        }
        public override string Handle(ElevatorModel e)
        {
            return "12";
        }
    }

    class Overloaded: State
    {
        public Overloaded()
        {
            name = "Перегружен";
        }
        public override string Handle(ElevatorModel e)
        {
            return "12";
        }
    }

    class PowerShortage: State
    {
        public PowerShortage()
        {
            name = "Нет питания";
        }
        public override string Handle(ElevatorModel e)
        {
            return "12";
        }
    }

    class Breakdown: State
    {
        public Breakdown()
        {
            name = "Авария";
        }
        public override string Handle(ElevatorModel e)
        {
            return "12";
        }
    }

    class ElevatorModel: Observable
    {
        public int floor { get; private set; }
        public int next_floor { get; private set; }
        public int max_mass { get; private set; }
        public int mass { get; private set; }
        public int powerShortageChance { get; private set; }
        private State state;
        public ElevatorModel()
        {
            floor = 1;
            next_floor = 1;
            max_mass = 250;
            mass = 0;
            powerShortageChance = 5;
            state = new Peace();
        }

        public void changeFloor()
        {
            floor = next_floor;
        }

        public void changeNextFloor(int nFloor)
        {
            next_floor = nFloor;
        }

        public void load()
        {
            mass += 70;
        }

        public void unload()
        {
            if (mass >= 70) mass -= 70;
        }

        public void changePower(int p)
        {
            powerShortageChance = p;
        }

        public string move()
        {
            return $"Текущий этаж = {floor}\nТекущая масса = {mass}\nТекущая вероятность отключения электроэнергии = {powerShortageChance}%\n{state.Handle(this)}\n";
        }

        public string info()
        {
            return $"Текущий этаж = {floor}\nТекущая масса = {mass}\nТекущая вероятность отключения электроэнергии = {powerShortageChance}%\nТекущее состояние: {state.name}\n";
        }

        public string setState(State s, string message)
        {
            state = s;
            return $"Состояние изменено: {s.name}\nПричина: {message}\n";
        }
    }
}
