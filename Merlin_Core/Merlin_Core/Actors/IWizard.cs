﻿using MerlinCore.Spells;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerlinCore.Actors
{
    public interface IWizard : IActor
    {
        void ChangeMana(int delta);
        int GetMana();
        void Cast(ISpell spell);
    }
}
