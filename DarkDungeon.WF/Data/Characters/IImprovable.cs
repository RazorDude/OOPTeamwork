using System;

namespace Data.Characters
{
    public interface IImprovable
    {
        void LevelUp();

        void GainExperience(int experience);
    }
}
