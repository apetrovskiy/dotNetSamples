/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/3/2013
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using MS.Internal.Automation;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Automation.Provider;
namespace System.Windows.Automation
{
	public sealed class AutomationElement : IAutomationElement
	{
		public struct AutomationElementInformation
		{
			private AutomationElement _el;
			private bool _useCache;
			public ControlType ControlType {
				get { return (ControlType)this._el.GetPatternPropertyValue(AutomationElement.ControlTypeProperty, this._useCache); }
			}
			public string LocalizedControlType {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.LocalizedControlTypeProperty, this._useCache); }
			}
			public string Name {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.NameProperty, this._useCache); }
			}
			public string AcceleratorKey {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.AcceleratorKeyProperty, this._useCache); }
			}
			public string AccessKey {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.AccessKeyProperty, this._useCache); }
			}
			public bool HasKeyboardFocus {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.HasKeyboardFocusProperty, this._useCache); }
			}
			public bool IsKeyboardFocusable {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsKeyboardFocusableProperty, this._useCache); }
			}
			public bool IsEnabled {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsEnabledProperty, this._useCache); }
			}
			public Rect BoundingRectangle {
				get { return (Rect)this._el.GetPatternPropertyValue(AutomationElement.BoundingRectangleProperty, this._useCache); }
			}
			public string HelpText {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.HelpTextProperty, this._useCache); }
			}
			public bool IsControlElement {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsControlElementProperty, this._useCache); }
			}
			public bool IsContentElement {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsContentElementProperty, this._useCache); }
			}
			public AutomationElement LabeledBy {
				get { return (AutomationElement)this._el.GetPatternPropertyValue(AutomationElement.LabeledByProperty, this._useCache); }
			}
			public string AutomationId {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.AutomationIdProperty, this._useCache); }
			}
			public string ItemType {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.ItemTypeProperty, this._useCache); }
			}
			public bool IsPassword {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsPasswordProperty, this._useCache); }
			}
			public string ClassName {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.ClassNameProperty, this._useCache); }
			}
			public int NativeWindowHandle {
				get { return (int)this._el.GetPatternPropertyValue(AutomationElement.NativeWindowHandleProperty, this._useCache); }
			}
			public int ProcessId {
				get { return (int)this._el.GetPatternPropertyValue(AutomationElement.ProcessIdProperty, this._useCache); }
			}
			public bool IsOffscreen {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsOffscreenProperty, this._useCache); }
			}
			public OrientationType Orientation {
				get { return (OrientationType)this._el.GetPatternPropertyValue(AutomationElement.OrientationProperty, this._useCache); }
			}
			public string FrameworkId {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.FrameworkIdProperty, this._useCache); }
			}
			public bool IsRequiredForForm {
				get { return (bool)this._el.GetPatternPropertyValue(AutomationElement.IsRequiredForFormProperty, this._useCache); }
			}
			public string ItemStatus {
				get { return (string)this._el.GetPatternPropertyValue(AutomationElement.ItemStatusProperty, this._useCache); }
			}
			internal AutomationElementInformation(AutomationElement el, bool useCache)
			{
				this._el = el;
				this._useCache = useCache;
			}
		}
		public static readonly object NotSupported = AutomationElementIdentifiers.NotSupported;
		public static readonly AutomationProperty IsControlElementProperty = AutomationElementIdentifiers.IsControlElementProperty;
		public static readonly AutomationProperty ControlTypeProperty = AutomationElementIdentifiers.ControlTypeProperty;
		public static readonly AutomationProperty IsContentElementProperty = AutomationElementIdentifiers.IsContentElementProperty;
		public static readonly AutomationProperty LabeledByProperty = AutomationElementIdentifiers.LabeledByProperty;
		public static readonly AutomationProperty NativeWindowHandleProperty = AutomationElementIdentifiers.NativeWindowHandleProperty;
		public static readonly AutomationProperty AutomationIdProperty = AutomationElementIdentifiers.AutomationIdProperty;
		public static readonly AutomationProperty ItemTypeProperty = AutomationElementIdentifiers.ItemTypeProperty;
		public static readonly AutomationProperty IsPasswordProperty = AutomationElementIdentifiers.IsPasswordProperty;
		public static readonly AutomationProperty LocalizedControlTypeProperty = AutomationElementIdentifiers.LocalizedControlTypeProperty;
		public static readonly AutomationProperty NameProperty = AutomationElementIdentifiers.NameProperty;
		public static readonly AutomationProperty AcceleratorKeyProperty = AutomationElementIdentifiers.AcceleratorKeyProperty;
		public static readonly AutomationProperty AccessKeyProperty = AutomationElementIdentifiers.AccessKeyProperty;
		public static readonly AutomationProperty HasKeyboardFocusProperty = AutomationElementIdentifiers.HasKeyboardFocusProperty;
		public static readonly AutomationProperty IsKeyboardFocusableProperty = AutomationElementIdentifiers.IsKeyboardFocusableProperty;
		public static readonly AutomationProperty IsEnabledProperty = AutomationElementIdentifiers.IsEnabledProperty;
		public static readonly AutomationProperty BoundingRectangleProperty = AutomationElementIdentifiers.BoundingRectangleProperty;
		public static readonly AutomationProperty ProcessIdProperty = AutomationElementIdentifiers.ProcessIdProperty;
		public static readonly AutomationProperty RuntimeIdProperty = AutomationElementIdentifiers.RuntimeIdProperty;
		public static readonly AutomationProperty ClassNameProperty = AutomationElementIdentifiers.ClassNameProperty;
		public static readonly AutomationProperty HelpTextProperty = AutomationElementIdentifiers.HelpTextProperty;
		public static readonly AutomationProperty ClickablePointProperty = AutomationElementIdentifiers.ClickablePointProperty;
		public static readonly AutomationProperty CultureProperty = AutomationElementIdentifiers.CultureProperty;
		public static readonly AutomationProperty IsOffscreenProperty = AutomationElementIdentifiers.IsOffscreenProperty;
		public static readonly AutomationProperty OrientationProperty = AutomationElementIdentifiers.OrientationProperty;
		public static readonly AutomationProperty FrameworkIdProperty = AutomationElementIdentifiers.FrameworkIdProperty;
		public static readonly AutomationProperty IsRequiredForFormProperty = AutomationElementIdentifiers.IsRequiredForFormProperty;
		public static readonly AutomationProperty ItemStatusProperty = AutomationElementIdentifiers.ItemStatusProperty;
		public static readonly AutomationProperty IsDockPatternAvailableProperty = AutomationElementIdentifiers.IsDockPatternAvailableProperty;
		public static readonly AutomationProperty IsExpandCollapsePatternAvailableProperty = AutomationElementIdentifiers.IsExpandCollapsePatternAvailableProperty;
		public static readonly AutomationProperty IsGridItemPatternAvailableProperty = AutomationElementIdentifiers.IsGridItemPatternAvailableProperty;
		public static readonly AutomationProperty IsGridPatternAvailableProperty = AutomationElementIdentifiers.IsGridPatternAvailableProperty;
		public static readonly AutomationProperty IsInvokePatternAvailableProperty = AutomationElementIdentifiers.IsInvokePatternAvailableProperty;
		public static readonly AutomationProperty IsMultipleViewPatternAvailableProperty = AutomationElementIdentifiers.IsMultipleViewPatternAvailableProperty;
		public static readonly AutomationProperty IsRangeValuePatternAvailableProperty = AutomationElementIdentifiers.IsRangeValuePatternAvailableProperty;
		public static readonly AutomationProperty IsSelectionItemPatternAvailableProperty = AutomationElementIdentifiers.IsSelectionItemPatternAvailableProperty;
		public static readonly AutomationProperty IsSelectionPatternAvailableProperty = AutomationElementIdentifiers.IsSelectionPatternAvailableProperty;
		public static readonly AutomationProperty IsScrollPatternAvailableProperty = AutomationElementIdentifiers.IsScrollPatternAvailableProperty;
		public static readonly AutomationProperty IsScrollItemPatternAvailableProperty = AutomationElementIdentifiers.IsScrollItemPatternAvailableProperty;
		public static readonly AutomationProperty IsTablePatternAvailableProperty = AutomationElementIdentifiers.IsTablePatternAvailableProperty;
		public static readonly AutomationProperty IsTableItemPatternAvailableProperty = AutomationElementIdentifiers.IsTableItemPatternAvailableProperty;
		public static readonly AutomationProperty IsTextPatternAvailableProperty = AutomationElementIdentifiers.IsTextPatternAvailableProperty;
		public static readonly AutomationProperty IsTogglePatternAvailableProperty = AutomationElementIdentifiers.IsTogglePatternAvailableProperty;
		public static readonly AutomationProperty IsTransformPatternAvailableProperty = AutomationElementIdentifiers.IsTransformPatternAvailableProperty;
		public static readonly AutomationProperty IsValuePatternAvailableProperty = AutomationElementIdentifiers.IsValuePatternAvailableProperty;
		public static readonly AutomationProperty IsWindowPatternAvailableProperty = AutomationElementIdentifiers.IsWindowPatternAvailableProperty;
		public static readonly AutomationEvent ToolTipOpenedEvent = AutomationElementIdentifiers.ToolTipOpenedEvent;
		public static readonly AutomationEvent ToolTipClosedEvent = AutomationElementIdentifiers.ToolTipClosedEvent;
		public static readonly AutomationEvent StructureChangedEvent = AutomationElementIdentifiers.StructureChangedEvent;
		public static readonly AutomationEvent MenuOpenedEvent = AutomationElementIdentifiers.MenuOpenedEvent;
		public static readonly AutomationEvent AutomationPropertyChangedEvent = AutomationElementIdentifiers.AutomationPropertyChangedEvent;
		public static readonly AutomationEvent AutomationFocusChangedEvent = AutomationElementIdentifiers.AutomationFocusChangedEvent;
		public static readonly AutomationEvent AsyncContentLoadedEvent = AutomationElementIdentifiers.AsyncContentLoadedEvent;
		public static readonly AutomationEvent MenuClosedEvent = AutomationElementIdentifiers.MenuClosedEvent;
		public static readonly AutomationEvent LayoutInvalidatedEvent = AutomationElementIdentifiers.LayoutInvalidatedEvent;
		private SafeNodeHandle _hnode;
		private int[] _runtimeId;
		private object[,] _cachedValues;
		private int _cachedValuesIndex;
		private UiaCoreApi.UiaCacheRequest _request;
		private AutomationElement _cachedParent;
		private AutomationElement _cachedFirstChild;
		private AutomationElement _cachedNextSibling;
		public static AutomationElement RootElement {
			get {
				SafeNodeHandle hnode = UiaCoreApi.UiaGetRootNode();
				UiaCoreApi.UiaCacheRequest currentUiaCacheRequest = CacheRequest.CurrentUiaCacheRequest;
				UiaCoreApi.UiaCacheResponse response = UiaCoreApi.UiaGetUpdatedCache(hnode, currentUiaCacheRequest, UiaCoreApi.NormalizeState.None, null);
				return CacheHelper.BuildAutomationElementsFromResponse(currentUiaCacheRequest, response);
			}
		}
		public static AutomationElement FocusedElement {
			get { return AutomationElement.DrillForPointOrFocus(false, new Point(0.0, 0.0), CacheRequest.CurrentUiaCacheRequest); }
		}
		public AutomationElement.AutomationElementInformation Cached {
			get { return new AutomationElement.AutomationElementInformation(this, true); }
		}
		public AutomationElement.AutomationElementInformation Current {
			get { return new AutomationElement.AutomationElementInformation(this, false); }
		}
		public AutomationElement CachedParent {
			get {
				if (this._cachedParent == this) {
					throw new InvalidOperationException(SR.Get("CachedPropertyNotRequested"));
				}
				return this._cachedParent;
			}
		}
		public AutomationElementCollection CachedChildren {
			get {
				if (this._cachedFirstChild == this) {
					throw new InvalidOperationException(SR.Get("CachedPropertyNotRequested"));
				}
				int num = 0;
				AutomationElement automationElement = this._cachedFirstChild;
				while (automationElement != null) {
					num++;
					automationElement = automationElement._cachedNextSibling;
				}
				AutomationElement[] array = new AutomationElement[num];
				automationElement = this._cachedFirstChild;
				for (int i = 0; i < num; i++) {
					array[i] = automationElement;
					automationElement = automationElement._cachedNextSibling;
				}
				return new AutomationElementCollection(array);
			}
		}
		internal SafeNodeHandle RawNode {
			get { return this._hnode; }
		}
		internal AutomationElement(SafeNodeHandle hnode, object[,] cachedValues, int cachedValuesIndex, UiaCoreApi.UiaCacheRequest request)
		{
			this._hnode = hnode;
			this._cachedValues = cachedValues;
			this._cachedValuesIndex = cachedValuesIndex;
			this._request = request;
			this._runtimeId = (this.LookupCachedValue(AutomationElement.RuntimeIdProperty, false, true) as int[]);
			this._cachedParent = this;
			this._cachedFirstChild = this;
			this._cachedNextSibling = this;
		}
		~AutomationElement()
		{
		}
		static internal AutomationElement Wrap(SafeNodeHandle hnode)
		{
			if (hnode == null || hnode.IsInvalid) {
				return null;
			}
			return new AutomationElement(hnode, null, 0, null);
		}
		public override bool Equals(object obj)
		{
			AutomationElement automationElement = obj as AutomationElement;
			return obj != null && !(automationElement == null) && Misc.Compare(this, automationElement);
		}
		public override int GetHashCode()
		{
			int[] runtimeId = this.GetRuntimeId();
			int num = 0;
			if (runtimeId == null) {
				throw new InvalidOperationException(SR.Get("OperationCannotBePerformed"));
			}
			for (int i = 0; i < runtimeId.Length; i++) {
				num = (num * 2 ^ runtimeId[i]);
			}
			return num;
		}
		public static bool operator ==(AutomationElement left, AutomationElement right)
		{
			if (left == null) {
				return right == null;
			}
			if (right == null) {
				return left == null;
			}
			return left.Equals(right);
		}
		public static bool operator !=(AutomationElement left, AutomationElement right)
		{
			return !(left == right);
		}
		public int[] GetRuntimeId()
		{
			if (this._runtimeId != null) {
				return this._runtimeId;
			}
			int[] array = this.LookupCachedValue(AutomationElement.RuntimeIdProperty, false, true) as int[];
			if (array != null) {
				this._runtimeId = array;
				return this._runtimeId;
			}
			this.CheckElement();
			this._runtimeId = UiaCoreApi.UiaGetRuntimeId(this._hnode);
			return this._runtimeId;
		}
		public static AutomationElement FromPoint(Point pt)
		{
			return AutomationElement.DrillForPointOrFocus(true, pt, CacheRequest.CurrentUiaCacheRequest);
		}
		public static AutomationElement FromHandle(IntPtr hwnd)
		{
			Misc.ValidateArgument(hwnd != IntPtr.Zero, "HwndMustBeNonNULL");
			SafeNodeHandle safeNodeHandle = UiaCoreApi.UiaNodeFromHandle(hwnd);
			if (safeNodeHandle.IsInvalid) {
				return null;
			}
			UiaCoreApi.UiaCacheRequest currentUiaCacheRequest = CacheRequest.CurrentUiaCacheRequest;
			UiaCoreApi.UiaCacheResponse response = UiaCoreApi.UiaGetUpdatedCache(safeNodeHandle, currentUiaCacheRequest, UiaCoreApi.NormalizeState.None, null);
			return CacheHelper.BuildAutomationElementsFromResponse(currentUiaCacheRequest, response);
		}
		public static AutomationElement FromLocalProvider(IRawElementProviderSimple localImpl)
		{
			Misc.ValidateArgumentNonNull(localImpl, "localImpl");
			return AutomationElement.Wrap(UiaCoreApi.UiaNodeFromProvider(localImpl));
		}
		public object GetCurrentPropertyValue(AutomationProperty property)
		{
			return this.GetCurrentPropertyValue(property, false);
		}
		public object GetCurrentPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			Misc.ValidateArgumentNonNull(property, "property");
			this.CheckElement();
			AutomationPropertyInfo automationPropertyInfo;
			if (!Schema.GetPropertyInfo(property, out automationPropertyInfo)) {
				return new ArgumentException(SR.Get("UnsupportedProperty"));
			}
			object obj;
			UiaCoreApi.UiaGetPropertyValue(this._hnode, property.Id, out obj);
			if (obj != AutomationElement.NotSupported) {
				if (obj != null && automationPropertyInfo.ObjectConverter != null) {
					obj = automationPropertyInfo.ObjectConverter(obj);
				}
			} else {
				if (ignoreDefaultValue) {
					obj = AutomationElement.NotSupported;
				} else {
					obj = Schema.GetDefaultValue(property);
				}
			}
			return obj;
		}
		public object GetCurrentPattern(AutomationPattern pattern)
		{
			object result;
			if (!this.TryGetCurrentPattern(pattern, out result)) {
				throw new InvalidOperationException(SR.Get("UnsupportedPattern"));
			}
			return result;
		}
		public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
		{
			patternObject = null;
			Misc.ValidateArgumentNonNull(pattern, "pattern");
			this.CheckElement();
			SafePatternHandle safePatternHandle = null;
			try {
				safePatternHandle = UiaCoreApi.UiaGetPatternProvider(this._hnode, pattern.Id);
			} catch (Exception ex) {
				if (Misc.IsCriticalException(ex)) {
					throw ex;
				}
				bool result = false;
				return result;
			}
			if (safePatternHandle.IsInvalid) {
				return false;
			}
			patternObject = Misc.WrapInterfaceOnClientSide(this, safePatternHandle, pattern);
			return patternObject != null;
		}
		public object GetCachedPropertyValue(AutomationProperty property)
		{
			return this.GetCachedPropertyValue(property, false);
		}
		public object GetCachedPropertyValue(AutomationProperty property, bool ignoreDefaultValue)
		{
			Misc.ValidateArgumentNonNull(property, "property");
			object obj = this.LookupCachedValue(property, true, true);
			UiaCoreApi.IsErrorMarker(obj, true);
			if (obj == AutomationElement.NotSupported && !ignoreDefaultValue) {
				obj = Schema.GetDefaultValue(property);
			}
			return obj;
		}
		public object GetCachedPattern(AutomationPattern pattern)
		{
			object result;
			if (!this.TryGetCachedPattern(pattern, out result)) {
				throw new InvalidOperationException(SR.Get("UnsupportedPattern"));
			}
			return result;
		}
		public bool TryGetCachedPattern(AutomationPattern pattern, out object patternObject)
		{
			patternObject = null;
			Misc.ValidateArgumentNonNull(pattern, "pattern");
			object obj = this.LookupCachedValue(pattern, false, false);
			if (obj == null) {
				return false;
			}
			SafePatternHandle hPattern = (SafePatternHandle)obj;
			AutomationPatternInfo automationPatternInfo;
			if (!Schema.GetPatternInfo(pattern, out automationPatternInfo)) {
				throw new ArgumentException(SR.Get("UnsupportedPattern"));
			}
			patternObject = automationPatternInfo.ClientSideWrapper(this, hPattern, true);
			return patternObject != null;
		}
		public AutomationElement GetUpdatedCache(CacheRequest request)
		{
			Misc.ValidateArgumentNonNull(request, "request");
			this.CheckElement();
			UiaCoreApi.UiaCacheRequest uiaCacheRequest = request.GetUiaCacheRequest();
			UiaCoreApi.UiaCacheResponse response = UiaCoreApi.UiaGetUpdatedCache(this._hnode, uiaCacheRequest, UiaCoreApi.NormalizeState.None, null);
			return CacheHelper.BuildAutomationElementsFromResponse(uiaCacheRequest, response);
		}
		public AutomationElement FindFirst(TreeScope scope, Condition condition)
		{
			Misc.ValidateArgumentNonNull(condition, "condition");
			UiaCoreApi.UiaCacheResponse[] array = this.Find(scope, condition, CacheRequest.CurrentUiaCacheRequest, true, null);
			if (array.Length < 1) {
				return null;
			}
			return CacheHelper.BuildAutomationElementsFromResponse(CacheRequest.CurrentUiaCacheRequest, array[0]);
		}
		public AutomationElementCollection FindAll(TreeScope scope, Condition condition)
		{
			Misc.ValidateArgumentNonNull(condition, "condition");
			UiaCoreApi.UiaCacheRequest currentUiaCacheRequest = CacheRequest.CurrentUiaCacheRequest;
			UiaCoreApi.UiaCacheResponse[] array = this.Find(scope, condition, currentUiaCacheRequest, false, null);
			AutomationElement[] array2 = new AutomationElement[array.Length];
			for (int i = 0; i < array.Length; i++) {
				array2[i] = CacheHelper.BuildAutomationElementsFromResponse(currentUiaCacheRequest, array[i]);
			}
			return new AutomationElementCollection(array2);
		}
		public AutomationProperty[] GetSupportedProperties()
		{
			this.CheckElement();
			ArrayList arrayList = new ArrayList(4);
			arrayList.Add(Schema.GetBasicProperties());
			AutomationPattern[] supportedPatterns = this.GetSupportedPatterns();
			if (supportedPatterns != null && supportedPatterns.Length > 0) {
				AutomationPattern[] array = supportedPatterns;
				for (int i = 0; i < array.Length; i++) {
					AutomationPattern id = array[i];
					AutomationPatternInfo automationPatternInfo;
					if (Schema.GetPatternInfo(id, out automationPatternInfo) && automationPatternInfo.Properties != null) {
						arrayList.Add(automationPatternInfo.Properties);
					}
				}
			}
			return (AutomationProperty[])Misc.RemoveDuplicates(Misc.CombineArrays(arrayList, typeof(AutomationProperty)), typeof(AutomationProperty));
		}
		public AutomationPattern[] GetSupportedPatterns()
		{
			this.CheckElement();
			ArrayList arrayList = new ArrayList(4);
			AutomationPatternInfo[] patternInfoTable = Schema.GetPatternInfoTable();
			for (int i = 0; i < patternInfoTable.Length; i++) {
				AutomationPatternInfo automationPatternInfo = patternInfoTable[i];
				object obj;
				if (this.TryGetCurrentPattern(automationPatternInfo.ID, out obj)) {
					arrayList.Add(automationPatternInfo.ID);
				}
			}
			return (AutomationPattern[])arrayList.ToArray(typeof(AutomationPattern));
		}
		public void SetFocus()
		{
			this.CheckElement();
			object currentPropertyValue = this.GetCurrentPropertyValue(AutomationElement.IsKeyboardFocusableProperty);
			if (currentPropertyValue is bool && (bool)currentPropertyValue) {
				UiaCoreApi.UiaSetFocus(this._hnode);
				return;
			}
			throw new InvalidOperationException(SR.Get("SetFocusFailed"));
		}
		public bool TryGetClickablePoint(out Point pt)
		{
			pt = new Point(0.0, 0.0);
			object currentPropertyValue = this.GetCurrentPropertyValue(AutomationElement.ClickablePointProperty);
			if (currentPropertyValue == AutomationElement.NotSupported) {
				return false;
			}
			if (currentPropertyValue is Point) {
				if (double.IsNaN(((Point)currentPropertyValue).X) || double.IsNaN(((Point)currentPropertyValue).Y)) {
					return false;
				}
				AutomationElement automationElement = AutomationElement.FromPoint((Point)currentPropertyValue);
				while (automationElement != null) {
					if (automationElement == this) {
						pt = (Point)currentPropertyValue;
						return true;
					}
					automationElement = TreeWalker.RawViewWalker.GetParent(automationElement, CacheRequest.DefaultCacheRequest);
				}
			}
			return ClickablePoint.HitTestForClickablePoint(this, out pt);
		}
		public Point GetClickablePoint()
		{
			Point result;
			if (!this.TryGetClickablePoint(out result)) {
				throw new NoClickablePointException(SR.Get("LogicalElementNoClickablePoint"));
			}
			return result;
		}
		internal void CheckElement()
		{
			if (this._hnode == null || this._hnode.IsInvalid) {
				throw new InvalidOperationException(SR.Get("CacheRequestNeedElementReference"));
			}
		}
		internal AutomationElement Navigate(NavigateDirection direction, Condition condition, CacheRequest request)
		{
			this.CheckElement();
			UiaCoreApi.UiaCacheRequest uiaCacheRequest;
			if (request == null) {
				uiaCacheRequest = CacheRequest.DefaultUiaCacheRequest;
			} else {
				uiaCacheRequest = request.GetUiaCacheRequest();
			}
			UiaCoreApi.UiaCacheResponse response = UiaCoreApi.UiaNavigate(this._hnode, direction, condition, uiaCacheRequest);
			return CacheHelper.BuildAutomationElementsFromResponse(uiaCacheRequest, response);
		}
		internal AutomationElement Normalize(Condition condition, CacheRequest request)
		{
			this.CheckElement();
			UiaCoreApi.UiaCacheRequest uiaCacheRequest;
			if (request == null) {
				uiaCacheRequest = CacheRequest.DefaultUiaCacheRequest;
			} else {
				uiaCacheRequest = request.GetUiaCacheRequest();
			}
			UiaCoreApi.UiaCacheResponse response = UiaCoreApi.UiaGetUpdatedCache(this._hnode, uiaCacheRequest, UiaCoreApi.NormalizeState.Custom, condition);
			return CacheHelper.BuildAutomationElementsFromResponse(uiaCacheRequest, response);
		}
		internal object GetPatternPropertyValue(AutomationProperty property, bool useCache)
		{
			if (useCache) {
				return this.GetCachedPropertyValue(property);
			}
			return this.GetCurrentPropertyValue(property);
		}
		internal void SetCachedParent(AutomationElement cachedParent)
		{
			this._cachedParent = cachedParent;
			this._cachedNextSibling = null;
		}
		internal void SetCachedFirstChild(AutomationElement cachedFirstChild)
		{
			this._cachedFirstChild = cachedFirstChild;
		}
		internal void SetCachedNextSibling(AutomationElement cachedNextSibling)
		{
			this._cachedNextSibling = cachedNextSibling;
		}
		private object LookupCachedValue(AutomationIdentifier id, bool throwIfNotRequested, bool wrap)
		{
			if (this._cachedValues == null) {
				if (throwIfNotRequested) {
					throw new InvalidOperationException(SR.Get("CachedPropertyNotRequested"));
				}
				return null;
			} else {
				AutomationProperty automationProperty = id as AutomationProperty;
				bool flag = automationProperty != null;
				AutomationIdentifier[] array = flag ? ((AutomationIdentifier[])this._request.Properties) : ((AutomationIdentifier[])this._request.Patterns);
				bool flag2 = false;
				object obj = null;
				int num = flag ? 1 : (1 + this._request.Properties.Length);
				for (int i = 0; i < array.Length; i++) {
					if (array[i] == id) {
						flag2 = true;
						obj = this._cachedValues[this._cachedValuesIndex, i + num];
						break;
					}
				}
				if (!flag2) {
					if (throwIfNotRequested) {
						throw new InvalidOperationException(SR.Get("CachedPropertyNotRequested"));
					}
					return null;
				} else {
					if (!wrap || obj == null) {
						return obj;
					}
					AutomationPattern automationPattern = id as AutomationPattern;
					if (automationPattern != null) {
						SafePatternHandle hPattern = (SafePatternHandle)obj;
						obj = Misc.WrapInterfaceOnClientSide(this, hPattern, automationPattern);
					}
					return obj;
				}
			}
		}
		private static AutomationElement DrillForPointOrFocus(bool atPoint, Point pt, UiaCoreApi.UiaCacheRequest cacheRequest)
		{
			UiaCoreApi.UiaCacheResponse response;
			if (atPoint) {
				response = UiaCoreApi.UiaNodeFromPoint(pt.X, pt.Y, cacheRequest);
			} else {
				response = UiaCoreApi.UiaNodeFromFocus(cacheRequest);
			}
			return CacheHelper.BuildAutomationElementsFromResponse(cacheRequest, response);
		}
		private UiaCoreApi.UiaCacheResponse[] Find(TreeScope scope, Condition condition, UiaCoreApi.UiaCacheRequest request, bool findFirst, BackgroundWorker worker)
		{
			Misc.ValidateArgumentNonNull(condition, "condition");
			if (scope == (TreeScope)0) {
				throw new ArgumentException(SR.Get("TreeScopeNeedAtLeastOne"));
			}
			if ((scope & ~(TreeScope.Element | TreeScope.Children | TreeScope.Descendants)) != (TreeScope)0) {
				throw new ArgumentException(SR.Get("TreeScopeElementChildrenDescendantsOnly"));
			}
			UiaCoreApi.UiaFindParams findParams = default(UiaCoreApi.UiaFindParams);
			findParams.FindFirst = findFirst;
			if ((scope & TreeScope.Descendants) != (TreeScope)0) {
				findParams.MaxDepth = -1;
			} else {
				if ((scope & TreeScope.Children) != (TreeScope)0) {
					findParams.MaxDepth = 1;
				} else {
					findParams.MaxDepth = 0;
				}
			}
			if ((scope & TreeScope.Element) != (TreeScope)0) {
				findParams.ExcludeRoot = false;
			} else {
				findParams.ExcludeRoot = true;
			}
			return UiaCoreApi.UiaFind(this._hnode, findParams, condition, request);
		}
	}
}

