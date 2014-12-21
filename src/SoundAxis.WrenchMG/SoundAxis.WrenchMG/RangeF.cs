using System;

namespace SoundAxis.WrenchMG
{
	public class RangeF
	{
		static Random r = new Random();
		float _min;
		float _max;
		float _val;

		public RangeF ()
		{
		}

		public RangeF(float min, float max, float val)
		{
			Min = min;
			Max = max;
			CurrentValue = val;
		}

		public float Min
		{
			get { return _min; }
			set {
				_min = value;

				if (_val < _min)
					_val = _min;
			}
		}

		public float Max
		{
			get { return _max; }
			set {
				_max = value;

				if (_max < _val)
					_val = _max;
			}
		}

		public float CurrentValue
		{
			get { return _val; }
			set {
				_val = value;

				if (_val < _min)
					_val = _min;

				if (_val > _max)
					_val = _max;
			}
		}

		public float RandomInRange
		{
			get {
				float temp = (float)r.NextDouble ();
				temp *= (Max - Min);
				temp += Min;

				return temp;
			}
		}
	}
}

