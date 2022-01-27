using System;
using BotFramework.Behaviors;
using StardewValley;
using System.Collections.Generic;
using BotFramework.Controllers;
using BotFramework.Exceptions;
using BotFramework.Framework.States;
using StardewModdingAPI;

namespace BotFramework
{
    abstract class Bot : IBot, IEquatable<Bot>
	{
		protected IController _controller;

		protected IList<IState> _states;

		public Bot(Character character, IList<IState> states)
		{
			if (character == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(character);

			_states = states;
			CheckStates();

			BotManager.Attatch(this);
		}

		public Bot(Character character)
		{
			if (character == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(character);

			_states = DefaultStates();
			CheckStates();

			BotManager.Attatch(this);
		}

		public Bot()
		{
			if (DefaultCharacter() == null)
			{
				throw new BotRequiresCharacterException();
			}
			_controller = DefaultController(DefaultCharacter());

			_states = DefaultStates();
			CheckStates();

			BotManager.Attatch(this);
		}

		~Bot()
		{
			BotManager.Detatch(this);
		}

		public void UpdateTicked()
		{

		}

		public void DayStarted()
		{

		}

		public void ButtonPressed(SButton button)
		{

		}

		public void Warped()
		{

		}

		protected virtual IController DefaultController(Character character)
		{
			return new Controller(character);
		}

		protected abstract Character DefaultCharacter();

		protected abstract IList<IState> DefaultStates();

		protected void CheckStates()
		{
			for (int i = 0; i < _states.Count; i++)
			{
				if (_states.IndexOf(_states[i]) != i)
				{
					throw new DuplicateStateException(GetId(), _states[i]);
				}
			}
		}

		public abstract string GetId();

		public virtual string GetDescription()
		{
			return "No description provided.";
		}

		public virtual IController GetController()
		{
			return _controller;
		}

		public virtual Character GetCharacter()
		{
			return _controller.GetCharacter();
		}

		public virtual IList<IState> GetStates()
		{
			return _states;
		}

		public virtual bool Equals(Bot other)
		{
			return GetId() == other.GetId();
		}
	}
}
