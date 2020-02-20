public static class ExtensionMethods {
	
	public static float RemapFloatValueToRange (this float value, float range1Min, float range1Max, float range2Min,
		float range2Max) {
		return (value - range1Min) / (range1Max - range1Min) * (range2Max - range2Min) + range2Min;
	}
}
