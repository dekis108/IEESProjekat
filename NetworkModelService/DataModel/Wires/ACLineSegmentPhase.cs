using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class ACLineSegmentPhase : PowerSystemResource
    {
		public long ACLineSegment { get; set; }

		public ACLineSegmentPhase(long globalId) : base(globalId)
		{
		}


		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				ACLineSegmentPhase x = (ACLineSegmentPhase)obj;
				return x.ACLineSegment == this.ACLineSegment;
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}


		public override bool HasProperty(ModelCode property)
		{
			switch (property)
			{
				case ModelCode.ACLINESEGMENTPHASE_ACLINESEGMENT:
					return true;

				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.ACLINESEGMENTPHASE_ACLINESEGMENT:
					prop.SetValue(ACLineSegment);
					break;

				default:
					base.GetProperty(prop);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.ACLINESEGMENTPHASE_ACLINESEGMENT:
					ACLineSegment = property.AsReference();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		public override bool IsReferenced
		{
			get
			{
				return base.IsReferenced;
			}
		}


		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			base.GetReferences(references, refType);
		}

		public override void AddReference(ModelCode referenceId, long globalId) //TODO ovo mozda nije dobro podeseno
		{
			switch (referenceId)
			{

				default:
					base.AddReference(referenceId, globalId);
					break;
			}
		}

		public override void RemoveReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				default:
					base.RemoveReference(referenceId, globalId);
					break;
			}
		}
	}
}
