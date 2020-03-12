// IphoneTestModel.cs
//
// This file was automatically generated and should not be edited.
//

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using CoreML;
using CoreVideo;
using Foundation;

namespace TestApp1.iOS {
	/// <summary>
	/// Model Prediction Input Type
	/// </summary>
	public class IphoneTestModelInput : NSObject, IMLFeatureProvider
	{
		static readonly NSSet<NSString> featureNames = new NSSet<NSString> (
			new NSString ("image")
		);

		CVPixelBuffer image;

		/// <summary>
		/// Input image to be classified as color (kCVPixelFormatType_32BGRA) image buffer, 299 pizels wide by 299 pixels high
		/// </summary>
		/// <value>Input image to be classified</value>
		public CVPixelBuffer Image {
			get { return image; }
			set {
				if (value == null)
					throw new ArgumentNullException (nameof (value));

				image = value;
			}
		}

		public NSSet<NSString> FeatureNames {
			get { return featureNames; }
		}

		public MLFeatureValue GetFeatureValue (string featureName)
		{
			switch (featureName) {
			case "image":
				return MLFeatureValue.Create (Image);
			default:
				return null;
			}
		}

		public IphoneTestModelInput (CVPixelBuffer image)
		{
			if (image == null)
				throw new ArgumentNullException (nameof (image));

			Image = image;
		}
	}

	/// <summary>
	/// Model Prediction Output Type
	/// </summary>
	public class IphoneTestModelOutput : NSObject, IMLFeatureProvider
	{
		static readonly NSSet<NSString> featureNames = new NSSet<NSString> (
			new NSString ("classLabelProbs"), new NSString ("classLabel")
		);

		NSDictionary<NSObject, NSNumber> classLabelProbs;
		string classLabel;

		/// <summary>
		/// Probability of each category as dictionary of strings to doubles
		/// </summary>
		/// <value>Probability of each category</value>
		public NSDictionary<NSObject, NSNumber> ClassLabelProbs {
			get { return classLabelProbs; }
			set {
				if (value == null)
					throw new ArgumentNullException (nameof (value));

				classLabelProbs = value;
			}
		}

		/// <summary>
		/// Most likely image category as string value
		/// </summary>
		/// <value>Most likely image category</value>
		public string ClassLabel {
			get { return classLabel; }
			set {
				if (value == null)
					throw new ArgumentNullException (nameof (value));

				classLabel = value;
			}
		}

		public NSSet<NSString> FeatureNames {
			get { return featureNames; }
		}

		public MLFeatureValue GetFeatureValue (string featureName)
		{
			MLFeatureValue value;
			NSError err;

			switch (featureName) {
			case "classLabelProbs":
				value = MLFeatureValue.Create (ClassLabelProbs, out err);
				if (err != null)
					err.Dispose ();
				return value;
			case "classLabel":
				return MLFeatureValue.Create (ClassLabel);
			default:
				return null;
			}
		}

		public IphoneTestModelOutput (NSDictionary<NSObject, NSNumber> classLabelProbs, string classLabel)
		{
			if (classLabelProbs == null)
				throw new ArgumentNullException (nameof (classLabelProbs));

			if (classLabel == null)
				throw new ArgumentNullException (nameof (classLabel));

			ClassLabelProbs = classLabelProbs;
			ClassLabel = classLabel;
		}
	}

	/// <summary>
	/// Class for model loading and prediction
	/// </summary>
	public class IphoneTestModel : NSObject
	{
		readonly MLModel model;

		static NSUrl GetModelUrl ()
		{
			return NSBundle.MainBundle.GetUrlForResource ("IphoneTestModel", "mlmodelc");
		}

		public IphoneTestModel ()
		{
			NSError err;

			model = MLModel.Create (GetModelUrl (), out err);
		}

		IphoneTestModel (MLModel model)
		{
			this.model = model;
		}

		public static IphoneTestModel Create (NSUrl url, out NSError error)
		{
			if (url == null)
				throw new ArgumentNullException (nameof (url));

			var model = MLModel.Create (url, out error);

			if (model == null)
				return null;

			return new IphoneTestModel (model);
		}

		public static IphoneTestModel Create (MLModelConfiguration configuration, out NSError error)
		{
			if (configuration == null)
				throw new ArgumentNullException (nameof (configuration));

			var model = MLModel.Create (GetModelUrl (), configuration, out error);

			if (model == null)
				return null;

			return new IphoneTestModel (model);
		}

		public static IphoneTestModel Create (NSUrl url, MLModelConfiguration configuration, out NSError error)
		{
			if (url == null)
				throw new ArgumentNullException (nameof (url));

			if (configuration == null)
				throw new ArgumentNullException (nameof (configuration));

			var model = MLModel.Create (url, configuration, out error);

			if (model == null)
				return null;

			return new IphoneTestModel (model);
		}

		/// <summary>
		/// Make a prediction using the standard interface
		/// </summary>
		/// <param name="input">an instance of IphoneTestModelInput to predict from</param>
		/// <param name="error">If an error occurs, upon return contains an NSError object that describes the problem.</param>
		public IphoneTestModelOutput GetPrediction (IphoneTestModelInput input, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			var prediction = model.GetPrediction (input, out error);

			if (prediction == null)
				return null;

			var classLabelProbsValue = prediction.GetFeatureValue ("classLabelProbs").DictionaryValue;
			var classLabelValue = prediction.GetFeatureValue ("classLabel").StringValue;

			return new IphoneTestModelOutput (classLabelProbsValue, classLabelValue);
		}

		/// <summary>
		/// Make a prediction using the standard interface
		/// </summary>
		/// <param name="input">an instance of IphoneTestModelInput to predict from</param>
		/// <param name="options">prediction options</param>
		/// <param name="error">If an error occurs, upon return contains an NSError object that describes the problem.</param>
		public IphoneTestModelOutput GetPrediction (IphoneTestModelInput input, MLPredictionOptions options, out NSError error)
		{
			if (input == null)
				throw new ArgumentNullException (nameof (input));

			if (options == null)
				throw new ArgumentNullException (nameof (options));

			var prediction = model.GetPrediction (input, options, out error);

			if (prediction == null)
				return null;

			var classLabelProbsValue = prediction.GetFeatureValue ("classLabelProbs").DictionaryValue;
			var classLabelValue = prediction.GetFeatureValue ("classLabel").StringValue;

			return new IphoneTestModelOutput (classLabelProbsValue, classLabelValue);
		}

		/// <summary>
		/// Make a prediction using the convenience interface
		/// </summary>
		/// <param name="image">Input image to be classified as color (kCVPixelFormatType_32BGRA) image buffer, 299 pizels wide by 299 pixels high</param>
		/// <param name="error">If an error occurs, upon return contains an NSError object that describes the problem.</param>
		public IphoneTestModelOutput GetPrediction (CVPixelBuffer image, out NSError error)
		{
			var input = new IphoneTestModelInput (image);

			return GetPrediction (input, out error);
		}

		/// <summary>
		/// Make a prediction using the convenience interface
		/// </summary>
		/// <param name="image">Input image to be classified as color (kCVPixelFormatType_32BGRA) image buffer, 299 pizels wide by 299 pixels high</param>
		/// <param name="options">prediction options</param>
		/// <param name="error">If an error occurs, upon return contains an NSError object that describes the problem.</param>
		public IphoneTestModelOutput GetPrediction (CVPixelBuffer image, MLPredictionOptions options, out NSError error)
		{
			var input = new IphoneTestModelInput (image);

			return GetPrediction (input, options, out error);
		}
	}
}
