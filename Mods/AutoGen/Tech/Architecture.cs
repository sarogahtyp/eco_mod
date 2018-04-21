namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(MasonSkill), 0)]    
    public partial class ArchitectureSkill : Skill
    {
        public override string FriendlyName { get { return "Architecture"; } }
        public override string Description { get { return Localizer.Do(""); } }

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class ArchitectureSkillBook : SkillBook<ArchitectureSkill, ArchitectureSkillScroll>
    {
        public override string FriendlyName { get { return "Architecture Skill Book"; } }
    }

    [Serialized]
    public partial class ArchitectureSkillScroll : SkillScroll<ArchitectureSkill, ArchitectureSkillBook>
    {
        public override string FriendlyName { get { return "Architecture Skill Scroll"; } }
    }

    [RequiresSkill(typeof(MortaringSkill), 0)] 
    public partial class ArchitectureSkillBookRecipe : Recipe
    {
        public ArchitectureSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ArchitectureSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<MortaredStoneItem>(typeof(ResearchEfficiencySkill), 10, ResearchEfficiencySkill.MultiplicativeStrategy), 
				new CraftingElement<HewnLogItem>(typeof(ResearchEfficiencySkill), 10, ResearchEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Architecture Skill Book", typeof(ArchitectureSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
