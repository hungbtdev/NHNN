var $ = require("jquery");
var ko = require("knockout");

var DevExpress = require('./dx-reportdesigner');
var dxa = require('@devexpress/analytics-core');
require("devextreme/ui/button_group");
DevExpress.Analytics = DevExpress.Analytics || dxa.Analytics;
DevExpress.RichEdit = DevExpress.RichEdit || require('devexpress-richedit');
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var DevExpress;
(function (DevExpress) {
    var Reporting;
    (function (Reporting) {
        var Designer;
        (function (Designer) {
            var Controls;
            (function (Controls) {
                var RichEdit;
                (function (RichEdit) {
                    var Internal;
                    (function (Internal) {
                        var XRRichTextCommandExecuter;
                        (function (XRRichTextCommandExecuter) {
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ChangeFontName"] = 11] = "ChangeFontName";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ChangeStyle"] = 12] = "ChangeStyle";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ChangeFontSize"] = 13] = "ChangeFontSize";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["MakeTextUpperCase"] = 16] = "MakeTextUpperCase";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["MakeTextLowerCase"] = 17] = "MakeTextLowerCase";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleTextCase"] = 19] = "ToggleTextCase";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontBold"] = 20] = "ToggleFontBold";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontItalic"] = 21] = "ToggleFontItalic";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontUnderline"] = 22] = "ToggleFontUnderline";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontDoubleUnderline"] = 23] = "ToggleFontDoubleUnderline";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontStrikeout"] = 24] = "ToggleFontStrikeout";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontSuperscript"] = 26] = "ToggleFontSuperscript";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleFontSubscript"] = 27] = "ToggleFontSubscript";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ClearFormatting"] = 30] = "ClearFormatting";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleParagraphAlignmentLeft"] = 37] = "ToggleParagraphAlignmentLeft";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleParagraphAlignmentCenter"] = 38] = "ToggleParagraphAlignmentCenter";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleParagraphAlignmentRight"] = 39] = "ToggleParagraphAlignmentRight";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ToggleParagraphAlignmentJustify"] = 40] = "ToggleParagraphAlignmentJustify";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ShowHyperlinkForm"] = 59] = "ShowHyperlinkForm";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ChangeFontForeColor"] = 28] = "ChangeFontForeColor";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["ChangeFontBackColor"] = 29] = "ChangeFontBackColor";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["InsertHtmlCommand"] = 376] = "InsertHtmlCommand";
                            XRRichTextCommandExecuter[XRRichTextCommandExecuter["CreateNewDocumentLocally"] = 412] = "CreateNewDocumentLocally";
                        })(XRRichTextCommandExecuter = Internal.XRRichTextCommandExecuter || (Internal.XRRichTextCommandExecuter = {}));
                        var RichAction;
                        (function (RichAction) {
                            RichAction[RichAction["OpenDocument"] = 0] = "OpenDocument";
                            RichAction[RichAction["SaveDocument"] = 1] = "SaveDocument";
                            RichAction[RichAction["NewDocument"] = 2] = "NewDocument";
                        })(RichAction = Internal.RichAction || (Internal.RichAction = {}));
                        ko.bindingHandlers["dxRichSurface"] = {
                            init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
                                $(element).children().remove();
                                var model = viewModel;
                                if (model.controller && model.controller.richEdit) {
                                    var _richElement = model.controller.richEdit._element;
                                    if (ko.dataFor(_richElement) && document.getElementById(_richElement.id)) {
                                        $(element).parent().css("display", "none");
                                    }
                                    else {
                                        $(element).append(_richElement);
                                        ko.applyBindings(model.controller.richEdit, _richElement);
                                    }
                                }
                                else {
                                    var editorOptions = valueAccessor();
                                    var templateHtml = DevExpress.Analytics.Widgets.Internal.getTemplate('dxrd-rich-edit');
                                    var inlineControl = editorOptions.inlineEdit;
                                    var richElement = $(element).append(templateHtml).children()[0];
                                    var richEditModel = new XRRichEditControlModel(richElement, inlineControl, model.selected);
                                    model.createController(richEditModel);
                                    ko.applyBindings(richEditModel, richElement);
                                }
                                return { controlsDescendantBindings: true };
                            }
                        };
                        var XRRichController = (function (_super) {
                            __extends(XRRichController, _super);
                            function XRRichController(richEdit, xrRichSurfaceModel) {
                                var _this = _super.call(this) || this;
                                _this.richEdit = richEdit;
                                _this.surface = xrRichSurfaceModel;
                                _this.init();
                                return _this;
                            }
                            Object.defineProperty(XRRichController.prototype, "controlModel", {
                                get: function () {
                                    return this.surface._control;
                                },
                                enumerable: true,
                                configurable: true
                            });
                            XRRichController.prototype.createSubscribtions = function () {
                                var _this = this;
                                this._disposables.push(this.controlModel._newDocumentData.subscribe(function (newData) {
                                    if (!!newData)
                                        _this.onDocumentDataChanged(newData.content);
                                }));
                                this._disposables.push(this.controlModel.serializableRtfString.subscribe(function (value) { return _this.rtfStringChanged(value); }));
                                this._disposables.push(this.richEdit.visible.subscribe(function (newValue) { return _this.onVisibilityChanged(newValue); }));
                            };
                            XRRichController.prototype.dispose = function () {
                                _super.prototype.dispose.call(this);
                                this.richEdit.dispose();
                                this.fontModel.dispose();
                                this.paddingModel.dispose();
                                this.richLoader.dispose();
                            };
                            XRRichController.prototype.init = function () {
                                var _this = this;
                                this.locker = new DevExpress.Reporting.Internal.Locker();
                                this.fontModel = new RichEditFontModel(this.controlModel.font, this.richEdit, this.controlModel.foreColor, this);
                                this.paddingModel = new RichEditPaddingModelWrapper(this.controlModel.padding, this.richEdit);
                                this.richLoader = new RichLoader(this.richEdit);
                                this.createSubscribtions();
                                if (this.surface.serializedRtf()) {
                                    this.richEdit.openDocument(this.surface.serializedRtf(), 2, $.noop, function () {
                                        _this.surface.isValid(false);
                                    });
                                }
                                else {
                                    this.rtfStringChanged(this.surface.serializedRtf());
                                }
                            };
                            XRRichController.prototype.setRtfString = function (newRtf) {
                                var _this = this;
                                this.locker.lock(function () {
                                    _this.surface.serializedRtf(newRtf);
                                });
                            };
                            XRRichController.prototype.rtfStringChanged = function (newRtfString) {
                                var _this = this;
                                if (newRtfString === undefined) {
                                    var openSaveAction = function () {
                                        _this.richEdit.openDocument(btoa(_this.surface._control.name()), DevExpress.RichEdit.DocumentFormat.PlainText, function () {
                                            _this.richEdit.selectAllWithActionAndRestore(function () {
                                                _this.richEdit.executeCommand(XRRichTextCommandExecuter.ChangeFontName, _this.fontModel.family.peek());
                                                _this.richEdit.executeCommand(XRRichTextCommandExecuter.ChangeFontSize, _this.fontModel.size.peek());
                                            });
                                            _this.richEdit.saveDocument(2, function (result) { return _this.setRtfString(result); });
                                        });
                                    };
                                    if (this.surface._control.name()) {
                                        openSaveAction();
                                    }
                                    else {
                                        var subcription = this.surface._control.name.subscribe(function (name) {
                                            openSaveAction();
                                            subcription.dispose();
                                        });
                                    }
                                }
                                else {
                                    if (this.locker.isUpdate)
                                        return;
                                    this.richEdit.openDocument(newRtfString, 2, $.noop, function () {
                                        _this.surface.isValid(false);
                                    });
                                }
                            };
                            XRRichController.prototype.checkValidationState = function () {
                                if (this.richEdit.documentIsEmpty() && !this._oldValidState) {
                                    this.surface.isValid(false);
                                    return false;
                                }
                                return true;
                            };
                            XRRichController.prototype.onVisibilityChanged = function (newVisibility) {
                                var _this = this;
                                if (!newVisibility) {
                                    if (this.checkValidationState())
                                        this.richEdit.saveDocument(2, function (newRtfString) {
                                            if (newRtfString !== _this.surface.serializedRtf())
                                                _this.controlModel._newDocumentData(null);
                                            _this.setRtfString(newRtfString);
                                        });
                                }
                                else {
                                    this._oldValidState = this.surface.isValid();
                                    this.surface.isValid(true);
                                    this.richEdit.getRealControl().focus();
                                }
                                if (this.richEdit)
                                    this.richEdit.focusChanged(newVisibility);
                            };
                            XRRichController.prototype.onDocumentDataChanged = function (newDocument) {
                                var _this = this;
                                this.richLoader.textConverted = function (newText) {
                                    if (_this.checkValidationState()) {
                                        _this.surface.isValid(true);
                                        _this.setRtfString(newText);
                                    }
                                };
                                this.richLoader.load({ data: newDocument, dataFormat: this.controlModel.format(), oldText: this.surface.serializedRtf() });
                            };
                            return XRRichController;
                        }(DevExpress.Analytics.Utils.Disposable));
                        Internal.XRRichController = XRRichController;
                        var RichEditCommand = (function () {
                            function RichEditCommand(code) {
                                this.code = code;
                            }
                            RichEditCommand.prototype.validate = function (htmlEvent) {
                                return htmlEvent.code === this.code;
                            };
                            return RichEditCommand;
                        }());
                        var ControlRichEditCommand = (function (_super) {
                            __extends(ControlRichEditCommand, _super);
                            function ControlRichEditCommand() {
                                return _super !== null && _super.apply(this, arguments) || this;
                            }
                            ControlRichEditCommand.prototype.validate = function (htmlEvent) {
                                return htmlEvent.code === this.code && htmlEvent.ctrlKey;
                            };
                            return ControlRichEditCommand;
                        }(RichEditCommand));
                        var XRRichEditControlModel = (function (_super) {
                            __extends(XRRichEditControlModel, _super);
                            function XRRichEditControlModel(element, inlineControl, selected) {
                                var _this = _super.call(this) || this;
                                _this.ignoreCommands = [
                                    new ControlRichEditCommand("KeyF"),
                                    new RichEditCommand("F11")
                                ];
                                _this.executeCommand = function (command, params, setFocus) {
                                    if (setFocus === void 0) { setFocus = false; }
                                    if (_this.getRealControlNative().core.commandManager) {
                                        _this.getRealControlNative().core.commandManager.getCommand(command).execute(false, params || undefined);
                                        if (setFocus)
                                            _this.getRealControl().focus();
                                    }
                                };
                                _this._disposables.push(_this.visible = ko.pureComputed({
                                    read: function () { return inlineControl.visible() && selected(); },
                                    write: function (value) { inlineControl.visible(value); }
                                }));
                                _this._disposables.push(_this.className = ko.computed(function () {
                                    return ["dxrd-rich-surface", _this.visible() ? "" : "dxrd-richedit-readonly"].join(" ");
                                }));
                                _this._element = element;
                                _this._element.id = "rich" + DevExpress.Analytics.Internal.guid().replace(/-/g, "");
                                _this._element.setAttribute("tabindex", "1");
                                _this._richEdit = new DevExpress.RichEdit.RichEdit(element, _this.createOptions());
                                _this.getRealControlNative().showPopupMenu = function () { };
                                _this.getRealControlNative().hidePopupMenu = function () { };
                                _this._dispatcher = new RichEditLoadDispatcher(_this);
                                _this.initFonts();
                                _this.createToolbar();
                                return _this;
                            }
                            XRRichEditControlModel.prototype.getToolbar = function () { return this._toolbar; };
                            XRRichEditControlModel.prototype.getRealControl = function () {
                                return this._richEdit;
                            };
                            XRRichEditControlModel.prototype.getRealControlNative = function () {
                                return this._richEdit["_native"];
                            };
                            XRRichEditControlModel.prototype.dispose = function () {
                                _super.prototype.dispose.call(this);
                                this._toolbar.dispose();
                                this._dispatcher.dispose();
                                this._richEdit.dispose();
                            };
                            XRRichEditControlModel.prototype.createOptions = function () {
                                var _this = this;
                                var options = {};
                                options.ribbon = { visible: false };
                                options.views = { viewType: 0 };
                                options.autoCorrect = { correctTwoInitialCapitals: true };
                                options.confirmOnLosingChanges = { enabled: false };
                                options.width = "100%";
                                options.height = "100%";
                                options.views.simpleViewSettings = { paddings: { left: 1.92, right: 1.92, top: 0.01, bottom: 0.01 } };
                                options.onKeyDown = function (s, e) {
                                    e.handled = _this.ignoreCommands.some(function (x) { return x.validate(e.htmlEvent); });
                                };
                                options.onSelectionChanged = function (s, e) { return _this._toolbar && _this._toolbar.onSelectionChanged(s, e); };
                                return options;
                            };
                            XRRichEditControlModel.prototype.initFonts = function () {
                                var _this = this;
                                var fonts = Object.keys(ko.unwrap(DevExpress.Analytics.Widgets.Internal.availableFonts));
                                this.getRealControl().document.fonts.getAllFontNames().forEach(function (fontName) { return fonts.some(function (restFN, index) {
                                    var exist = restFN === fontName;
                                    if (exist)
                                        fonts.splice(index, 1);
                                    return exist;
                                }) ? null : _this.getRealControl().document.fonts.getByName(fontName).delete(); });
                                fonts.forEach(function (name) { return _this.getRealControl().document.fonts.create(name, name); });
                                this.getRealControl().document.fonts.getAllFontNames().sort(function (a, b) { return (a < b) ? -1 : 1; });
                            };
                            XRRichEditControlModel.prototype.createToolbar = function () {
                                this._toolbarOptions = {
                                    commandManager: this.getRealControlNative().core.commandManager,
                                    executeCommand: this.executeCommand,
                                    richEditPublic: this._richEdit,
                                    visible: this.visible
                                };
                                this._toolbar = new Toolbar.ToolbarSurface(this._toolbarOptions);
                            };
                            XRRichEditControlModel.prototype.saveDocumentNative = function (documentFormat, onResultReady) {
                                if (onResultReady) {
                                    var handler = function (sender, arg2) {
                                        onResultReady(arg2.base64);
                                        sender["_native"].saving.removeHandler(handler, sender);
                                    };
                                    this.getRealControlNative().saving.addHandler(handler, this._richEdit);
                                }
                                this._richEdit.saveDocument(documentFormat);
                            };
                            XRRichEditControlModel.prototype.newDocumentNative = function (onResultReady) {
                                if (onResultReady) {
                                    var handler = function (sender, arg2) {
                                        onResultReady();
                                        sender["_native"].documentLoaded.removeHandler(handler, sender);
                                    };
                                    this.getRealControlNative().documentLoaded.addHandler(handler, this._richEdit);
                                }
                                this.executeCommand(XRRichTextCommandExecuter.CreateNewDocumentLocally);
                            };
                            XRRichEditControlModel.prototype.openDocumentNative = function (base64, documentFormat, onResultReady, onError) {
                                var _this = this;
                                var handler = function (sender, arg2) {
                                    onResultReady();
                                    sender["_native"].documentLoaded.removeHandler(handler, sender);
                                };
                                if (onResultReady) {
                                    this.getRealControlNative().documentLoaded.addHandler(handler, this._richEdit);
                                }
                                this._richEdit.openDocument(base64, undefined, documentFormat, function (result) {
                                    if (!result && onError) {
                                        _this.getRealControlNative().documentLoaded.removeHandler(handler, _this._richEdit);
                                        onError();
                                    }
                                });
                            };
                            XRRichEditControlModel.prototype.saveDocument = function (documentFormat, onResultReady) {
                                this._dispatcher.process({ documentConverted: onResultReady, queueAction: RichAction.SaveDocument, documentFormat: documentFormat, base64: undefined, ready: undefined, errorCallBack: undefined });
                            };
                            XRRichEditControlModel.prototype.newDocument = function (onResultReady) {
                                this._dispatcher.process({ documentConverted: undefined, queueAction: RichAction.NewDocument, documentFormat: undefined, base64: undefined, ready: onResultReady, errorCallBack: undefined });
                            };
                            XRRichEditControlModel.prototype.openDocument = function (base64, documentFormat, onResultReady, onError) {
                                this._dispatcher.process({ documentConverted: undefined, queueAction: RichAction.OpenDocument, documentFormat: documentFormat, base64: base64, ready: onResultReady, errorCallBack: onError });
                            };
                            XRRichEditControlModel.prototype.selectAllWithActionAndRestore = function (safeAction) {
                                var oldPos = this.getRealControl().selection.active;
                                this.getRealControl().selection.setSelection({ start: 0, length: this.getRealControl().document.length });
                                safeAction();
                                this.getRealControl().selection.setSelection(oldPos);
                            };
                            XRRichEditControlModel.prototype.changeSize = function (force) {
                                return this.getRealControlNative().core.simpleViewCanvasSizeManager &&
                                    this.getRealControlNative().core.simpleViewCanvasSizeManager.changeSize &&
                                    this.getRealControlNative().core.simpleViewCanvasSizeManager.changeSize(force);
                            };
                            XRRichEditControlModel.prototype.focusChanged = function (inFocus) {
                                if (!inFocus) {
                                    this.getRealControl().selection.setSelection(0);
                                    if (document.activeElement.classList.contains("dxreInputTarget"))
                                        this._element.focus();
                                }
                                this.changeSize(true);
                            };
                            XRRichEditControlModel.prototype.getText = function (interval) {
                                return this.getRealControl().document.getText(interval);
                            };
                            XRRichEditControlModel.prototype.documentIsEmpty = function () {
                                var startText = this.getText(new DevExpress.RichEdit.Interval(0, 2));
                                return startText.length == 1 && startText.charCodeAt(0) == 13;
                            };
                            return XRRichEditControlModel;
                        }(DevExpress.Analytics.Utils.Disposable));
                        Internal.XRRichEditControlModel = XRRichEditControlModel;
                        var RichLoader = (function (_super) {
                            __extends(RichLoader, _super);
                            function RichLoader(richEdit) {
                                var _this = _super.call(this) || this;
                                _this.richEdit = richEdit;
                                return _this;
                            }
                            Object.defineProperty(RichLoader.prototype, "textConverted", {
                                set: function (textConverted) {
                                    this._textConverted = textConverted;
                                },
                                enumerable: true,
                                configurable: true
                            });
                            RichLoader.prototype.load = function (loadData) {
                                var _this = this;
                                if (loadData.dataFormat === Controls.XRRichTextStreamType.HtmlText) {
                                    this.richEdit.newDocument(function () {
                                        _this.richEdit.executeCommand(XRRichTextCommandExecuter.InsertHtmlCommand, atob(loadData.data));
                                        _this.richEdit.saveDocument(2, function (result) {
                                            _this._textConverted(result);
                                        });
                                    });
                                    return;
                                }
                                var formatKey;
                                if (loadData.dataFormat === Controls.XRRichTextStreamType.PlainText) {
                                    formatKey = DevExpress.RichEdit.DocumentFormat.PlainText;
                                }
                                else if (loadData.dataFormat === Controls.XRRichTextStreamType.RtfText) {
                                    formatKey = 2;
                                }
                                else if (loadData.dataFormat === Controls.XRRichTextStreamType.XmlText) {
                                    formatKey = DevExpress.RichEdit.DocumentFormat.OpenXml;
                                }
                                this.richEdit.openDocument(loadData.data, formatKey, function () {
                                    _this.richEdit.saveDocument(2, function (result) {
                                        _this._textConverted(result);
                                    });
                                }, function () {
                                    _this.richEdit.openDocument(loadData.oldText, 2, function () {
                                        _this.richEdit.saveDocument(2, function (result) {
                                            _this._textConverted(result);
                                            DevExpress.Analytics.Internal.NotifyAboutWarning("The document is corrupted and cannot be opened", true);
                                        });
                                    });
                                });
                            };
                            return RichLoader;
                        }(DevExpress.Analytics.Utils.Disposable));
                        Internal.RichLoader = RichLoader;
                        var RichEditPaddingModelWrapper = (function (_super) {
                            __extends(RichEditPaddingModelWrapper, _super);
                            function RichEditPaddingModelWrapper(padding, _richEdit) {
                                var _this = _super.call(this) || this;
                                _this._richEdit = _richEdit;
                                _this._setPaddings = function () {
                                    ["left", "right", "top", "bottom"].forEach(function (side) {
                                        _this._richEdit.getRealControlNative().core.innerClientProperties.viewsSettings.paddings[side] = Designer.Internal.recalculateUnit(_this._paddingModel[side]() || 0.01, _this._paddingModel.dpi());
                                    });
                                    _this._richEdit.changeSize(true);
                                };
                                _this._paddingModel = new DevExpress.Analytics.Elements.PaddingModel();
                                _this._disposables.push(padding.subscribe(function (newVal) {
                                    _this._paddingModel.applyFromString(newVal);
                                    _this._setPaddings();
                                }));
                                _this._disposables.push(_this._paddingModel);
                                return _this;
                            }
                            return RichEditPaddingModelWrapper;
                        }(DevExpress.Analytics.Utils.Disposable));
                        Internal.RichEditPaddingModelWrapper = RichEditPaddingModelWrapper;
                        var RichEditFontModel = (function (_super) {
                            __extends(RichEditFontModel, _super);
                            function RichEditFontModel(value, richEdit, foreColor, controller) {
                                var _this = _super.call(this, value) || this;
                                _this.richEdit = richEdit;
                                _this.controller = controller;
                                _this._disposables.push(_this.family.subscribe(function (newFamily) { _this.doFontChangeAction(function () { _this.onFontFamilyChanged(newFamily); }); }));
                                _this._disposables.push(_this.size.subscribe(function (newsize) { _this.doFontChangeAction(function () { _this.onSizeChanged(newsize); }); }));
                                _this._disposables.push(foreColor.subscribe(function (newColor) { _this.doFontChangeAction(function () { _this.onColorChanged(newColor); }); }));
                                _this._disposables.push(_this.modificators.bold.subscribe(function (newbold) { _this.doFontChangeAction(function () { _this.onBoldChanged(newbold); }); }));
                                _this._disposables.push(_this.modificators.italic.subscribe(function (newitalic) { _this.doFontChangeAction(function () { _this.onuItalicChanged(newitalic); }); }));
                                _this._disposables.push(_this.modificators.strikeout.subscribe(function (newstrikeout) { _this.doFontChangeAction(function () { _this.onStrikeoutChanged(newstrikeout); }); }));
                                _this._disposables.push(_this.modificators.underline.subscribe(function (newunderline) { _this.doFontChangeAction(function () { _this.onUnderlineChanged(newunderline); }); }));
                                return _this;
                            }
                            RichEditFontModel.prototype.doFontChangeAction = function (fontAction) {
                                var _this = this;
                                if (!this.richEdit.visible()) {
                                    this.richEdit.selectAllWithActionAndRestore(fontAction);
                                }
                                else {
                                    fontAction();
                                }
                                if (!this.richEdit.visible()) {
                                    this.richEdit.saveDocument(2, function (newRtf) {
                                        _this.controller.setRtfString(newRtf);
                                    });
                                }
                            };
                            RichEditFontModel.prototype.onColorChanged = function (newColor) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ChangeFontForeColor, DevExpress.Analytics.Utils.colorToInt(newColor));
                            };
                            RichEditFontModel.prototype.onUnderlineChanged = function (newunderline) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ToggleFontUnderline);
                            };
                            RichEditFontModel.prototype.onStrikeoutChanged = function (newstrikeout) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ToggleFontStrikeout);
                            };
                            RichEditFontModel.prototype.onuItalicChanged = function (newitalic) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ToggleFontItalic);
                            };
                            RichEditFontModel.prototype.onBoldChanged = function (newbold) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ToggleFontBold);
                            };
                            RichEditFontModel.prototype.onSizeChanged = function (newsize) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ChangeFontSize, newsize);
                            };
                            RichEditFontModel.prototype.onFontFamilyChanged = function (newFamily) {
                                this.richEdit.executeCommand(XRRichTextCommandExecuter.ChangeFontName, newFamily);
                            };
                            return RichEditFontModel;
                        }(DevExpress.Analytics.Widgets.Internal.FontModel));
                        Internal.RichEditFontModel = RichEditFontModel;
                        var InlineRichEditControl = (function (_super) {
                            __extends(InlineRichEditControl, _super);
                            function InlineRichEditControl() {
                                return _super !== null && _super.apply(this, arguments) || this;
                            }
                            return InlineRichEditControl;
                        }(DevExpress.Analytics.Internal.InlineTextEdit));
                        Internal.InlineRichEditControl = InlineRichEditControl;
                        var Toolbar;
                        (function (Toolbar) {
                            var ParagraphAlignment;
                            (function (ParagraphAlignment) {
                                ParagraphAlignment[ParagraphAlignment["Left"] = 0] = "Left";
                                ParagraphAlignment[ParagraphAlignment["Right"] = 1] = "Right";
                                ParagraphAlignment[ParagraphAlignment["Center"] = 2] = "Center";
                                ParagraphAlignment[ParagraphAlignment["Justify"] = 3] = "Justify";
                            })(ParagraphAlignment = Toolbar.ParagraphAlignment || (Toolbar.ParagraphAlignment = {}));
                            var ComponentCommon = (function (_super) {
                                __extends(ComponentCommon, _super);
                                function ComponentCommon(options, info) {
                                    var _this = _super.call(this) || this;
                                    _this.itemKey = "value";
                                    _this.locker = new DevExpress.Reporting.Internal.Locker();
                                    _this.options = options;
                                    _this.value = ko.observable();
                                    if (info.template)
                                        _this.template = info.template;
                                    _this.init(info);
                                    return _this;
                                }
                                ComponentCommon.prototype._updateStateInternal = function () {
                                    var _this = this;
                                    this.locker.lock(function () { return _this.updateState(); });
                                };
                                ;
                                ComponentCommon.prototype._executeCommand = function (value, command) {
                                    if (this.locker.isUpdate)
                                        return;
                                    if (this.action)
                                        this.action(this.options.richEditPublic, value);
                                    else
                                        this.options.executeCommand(command, this.hasCustomValue() ? this.getConverter().toModel(value) : undefined, true);
                                    this._updateStateInternal();
                                };
                                ComponentCommon.prototype.executeCommand = function (value, command) {
                                    this._executeCommand(value, command);
                                };
                                ComponentCommon.prototype.unwrapItem = function (item) {
                                    return $.extend({}, item, { command: XRRichTextCommandExecuter[item.command] });
                                };
                                ComponentCommon.prototype.getConverter = function () {
                                    return {
                                        toModel: function (newValue) { return newValue; },
                                        fromModel: function (newValue) { return newValue; },
                                    };
                                };
                                ComponentCommon.prototype.init = function (info) {
                                    if (info) {
                                        this.id = info.id;
                                        this.text = info.text;
                                        this.visible = info.visible === false ? false : true;
                                        if (info.action)
                                            this.action = info.action;
                                    }
                                };
                                ComponentCommon.prototype.hasCustomValue = function () {
                                    return false;
                                };
                                return ComponentCommon;
                            }(DevExpress.Analytics.Utils.Disposable));
                            var CustomComponent = (function (_super) {
                                __extends(CustomComponent, _super);
                                function CustomComponent() {
                                    return _super !== null && _super.apply(this, arguments) || this;
                                }
                                CustomComponent.prototype.updateState = function () { };
                                return CustomComponent;
                            }(ComponentCommon));
                            Toolbar.CustomComponent = CustomComponent;
                            var Component = (function (_super) {
                                __extends(Component, _super);
                                function Component() {
                                    return _super !== null && _super.apply(this, arguments) || this;
                                }
                                Component.prototype.init = function (info) {
                                    var _this = this;
                                    _super.prototype.init.call(this, info);
                                    this.item = this.unwrapItem(info);
                                    this._command = this.item.command;
                                    if (this._command && this.options.commandManager && this.options.commandManager.commands[this._command].getCurrentValue) {
                                        this.value(this.getConverter().fromModel(this.options.commandManager.commands[this._command].getCurrentValue()));
                                        this.locker.lock(function () {
                                            _this._updateStateInternal();
                                        });
                                    }
                                    this._disposables.push(this.value.subscribe(function (value) { _this._executeCommand(value, _this.item.command); }));
                                };
                                Component.prototype.updateState = function () {
                                    if (this.value && this._command && this.options.commandManager.commands[this._command].getCurrentValue && this.hasCustomValue())
                                        this.value(this.getConverter().fromModel(this.options.commandManager.commands[this._command].getCurrentValue()));
                                };
                                return Component;
                            }(ComponentCommon));
                            Toolbar.Component = Component;
                            var ComponentButtonGroup = (function (_super) {
                                __extends(ComponentButtonGroup, _super);
                                function ComponentButtonGroup(options, info) {
                                    var _this = _super.call(this, options, info) || this;
                                    _this.itemKey = "command";
                                    _this.template = _this.template || "dxrd-rich-edit-toolbar-button-group";
                                    return _this;
                                }
                                ComponentButtonGroup.prototype.init = function (info) {
                                    var _this = this;
                                    _super.prototype.init.call(this, info);
                                    this.selectionMode = info.selectionMode || "single";
                                    this.selectedItems = ko.observableArray([]);
                                    this.items = info.items.map(function (item) { return _this.unwrapItem(item); });
                                    this._disposables.push(this.selectedItems.subscribe(function (changes) {
                                        _this.onSelectItems(changes);
                                    }, null, "arrayChange"));
                                };
                                ComponentButtonGroup.prototype.onSelectItems = function (changes) {
                                    var _this = this;
                                    changes.forEach(function (change) {
                                        if (_this.selectionMode === 'multiple' && change.status === 'deleted' || change.status === 'added') {
                                            _this._executeCommand(change.value.value, change.value.command);
                                        }
                                    });
                                };
                                ComponentButtonGroup.prototype.hasCustomValue = function () {
                                    return false;
                                };
                                ComponentButtonGroup.prototype.getCommand = function (item) {
                                    return item.command;
                                };
                                ComponentButtonGroup.prototype.updateState = function () {
                                    var _this = this;
                                    var selected = [];
                                    this.items.forEach(function (item) {
                                        var command = _this.getCommand(item);
                                        if (item.command === command) {
                                            var value = _this.options.commandManager.commands[command].getCurrentValue && _this.options.commandManager.commands[command].getCurrentValue();
                                            if ((!!value || command === XRRichTextCommandExecuter.ToggleParagraphAlignmentLeft && value === ParagraphAlignment.Left) && (!_this.hasCustomValue() || value === item[_this.itemKey])) {
                                                selected.push(item);
                                            }
                                        }
                                    });
                                    this.selectedItems(selected);
                                };
                                return ComponentButtonGroup;
                            }(ComponentCommon));
                            Toolbar.ComponentButtonGroup = ComponentButtonGroup;
                            var ComponentTextAligment = (function (_super) {
                                __extends(ComponentTextAligment, _super);
                                function ComponentTextAligment() {
                                    return _super !== null && _super.apply(this, arguments) || this;
                                }
                                ComponentTextAligment.prototype.getCommand = function (item) {
                                    var command = item.command;
                                    if (!this.options.commandManager.commands[command].getCurrentValue)
                                        return command;
                                    switch (this.options.commandManager.commands[command].getCurrentValue()) {
                                        case ParagraphAlignment.Left:
                                            return XRRichTextCommandExecuter.ToggleParagraphAlignmentLeft;
                                        case ParagraphAlignment.Right:
                                            return XRRichTextCommandExecuter.ToggleParagraphAlignmentRight;
                                        case ParagraphAlignment.Center:
                                            return XRRichTextCommandExecuter.ToggleParagraphAlignmentCenter;
                                        default:
                                            return command;
                                    }
                                };
                                return ComponentTextAligment;
                            }(ComponentButtonGroup));
                            Toolbar.ComponentTextAligment = ComponentTextAligment;
                            var ComponentButton = (function (_super) {
                                __extends(ComponentButton, _super);
                                function ComponentButton(options, info) {
                                    var _this = _super.call(this, options, info) || this;
                                    _this.icon = info.icon;
                                    _this.hint = info.hint;
                                    _this.template = _this.template || "dxrd-button-with-template";
                                    return _this;
                                }
                                ComponentButton.prototype.clickAction = function () {
                                    this._executeCommand(undefined, this.item.command);
                                };
                                return ComponentButton;
                            }(Component));
                            Toolbar.ComponentButton = ComponentButton;
                            var ComponentComboBox = (function (_super) {
                                __extends(ComponentComboBox, _super);
                                function ComponentComboBox(options, info) {
                                    var _this = _super.call(this, options, info) || this;
                                    _this.validationRules = [];
                                    _this.supportCustomValue = false;
                                    _this.items = info.items;
                                    _this.template = _this.template || "dxrd-rich-toolbar-combobox";
                                    return _this;
                                }
                                ComponentComboBox.prototype.getConverter = function () {
                                    return {
                                        fromModel: function (newValue) { return newValue && newValue.name; },
                                        toModel: function (newValue) { return newValue; },
                                    };
                                };
                                ComponentComboBox.prototype.hasCustomValue = function () { return true; };
                                return ComponentComboBox;
                            }(Component));
                            Toolbar.ComponentComboBox = ComponentComboBox;
                            var ComponentFontSizeComboBox = (function (_super) {
                                __extends(ComponentFontSizeComboBox, _super);
                                function ComponentFontSizeComboBox() {
                                    var _this = _super !== null && _super.apply(this, arguments) || this;
                                    _this.validationRules = [{ type: "numeric" }];
                                    _this.supportCustomValue = true;
                                    return _this;
                                }
                                ComponentFontSizeComboBox.prototype.getConverter = function () {
                                    return {
                                        fromModel: function (newValue) { return newValue; },
                                        toModel: function (newValue) { return newValue; },
                                    };
                                };
                                return ComponentFontSizeComboBox;
                            }(ComponentComboBox));
                            Toolbar.ComponentFontSizeComboBox = ComponentFontSizeComboBox;
                            var ComponentColorPicker = (function (_super) {
                                __extends(ComponentColorPicker, _super);
                                function ComponentColorPicker(options, info) {
                                    var _this = _super.call(this, options, info) || this;
                                    _this.template = _this.template || "dxrd-richEdit-toolbar-colorpicker";
                                    return _this;
                                }
                                ComponentColorPicker.prototype.getConverter = function () {
                                    var _this = this;
                                    return {
                                        fromModel: function (newValue) {
                                            if (newValue && !newValue.isEmpty)
                                                return DevExpress.Analytics.Utils.intToColor(newValue.rgb, false);
                                            else
                                                return newValue && _this.item.defaultValue;
                                        },
                                        toModel: function (newValue) { return newValue; }
                                    };
                                };
                                ComponentColorPicker.prototype.hasCustomValue = function () { return true; };
                                return ComponentColorPicker;
                            }(Component));
                            Toolbar.ComponentColorPicker = ComponentColorPicker;
                            var ComponentCollection = (function () {
                                function ComponentCollection(id, title, visible, template) {
                                    if (title === void 0) { title = ""; }
                                    if (visible === void 0) { visible = true; }
                                    if (template === void 0) { template = "dxrd-rich-edit-toolbar-component-collection"; }
                                    var _this = this;
                                    this.id = id;
                                    this.title = title;
                                    this.visible = visible;
                                    this.template = template;
                                    this.showTitle = function () { return _this.title; };
                                }
                                return ComponentCollection;
                            }());
                            Toolbar.ComponentCollection = ComponentCollection;
                            var ToolbarSurface = (function (_super) {
                                __extends(ToolbarSurface, _super);
                                function ToolbarSurface(options) {
                                    var _this = _super.call(this) || this;
                                    _this._popover = new Reporting.Viewer.Widgets.Internal.PopupComponentBase();
                                    _this._getDefaultItems = function (fonts) {
                                        return [
                                            {
                                                id: RichEdit.ToolbarGroupId.AlignmentAndFormatting,
                                                items: [
                                                    {
                                                        id: RichEdit.ToolbarActionId.ParagraphAlignmentButtonGroup,
                                                        actionType: "ButtonGroup",
                                                        selectionMode: "single",
                                                        _customComponent: "alignmentButtonGroup",
                                                        items: [
                                                            { actionType: "Button", command: "ToggleParagraphAlignmentLeft", icon: " dxre-icon-AlignLeft", hint: DevExpress.Analytics.Utils.getLocalization("Align Text Left", "XtraRichEditStringId.MenuCmd_ParagraphAlignmentLeft") },
                                                            { actionType: "Button", command: "ToggleParagraphAlignmentCenter", icon: " dxre-icon-AlignCenter", hint: DevExpress.Analytics.Utils.getLocalization("Center", "XtraRichEditStringId.MenuCmd_ParagraphAlignmentCenter") },
                                                            { actionType: "Button", command: "ToggleParagraphAlignmentRight", icon: " dxre-icon-AlignRight", hint: DevExpress.Analytics.Utils.getLocalization("Align Text Right", "XtraRichEditStringId.MenuCmd_ParagraphAlignmentRight") }
                                                        ]
                                                    },
                                                    {
                                                        id: RichEdit.ToolbarActionId.HyperlinkButton, actionType: "Button", command: "ShowHyperlinkForm", icon: " dxre-icon-Hyperlink", hint: DevExpress.Analytics.Utils.getLocalization("Hyperlink...", "XtraRichEditStringId.MenuCmd_Hyperlink"),
                                                    },
                                                    {
                                                        id: RichEdit.ToolbarActionId.ClearFormattingButton, actionType: "Button", command: "ClearFormatting", icon: " dxre-icon-ClearFormatting", hint: DevExpress.Analytics.Utils.getLocalization("Clear Formatting", "XtraRichEditStringId.MenuCmd_ClearFormatting")
                                                    }
                                                ],
                                            },
                                            {
                                                id: RichEdit.ToolbarGroupId.FontStyleAndCase,
                                                items: [
                                                    {
                                                        id: RichEdit.ToolbarActionId.FontStyleButtonGroup,
                                                        actionType: "ButtonGroup",
                                                        selectionMode: "multiple",
                                                        items: [
                                                            { actionType: "Button", command: "ToggleFontBold", icon: " dxre-icon-Bold", hint: DevExpress.Analytics.Utils.getLocalization("Bold", "System.Drawing.Font.Bold") },
                                                            { actionType: "Button", command: "ToggleFontItalic", icon: " dxre-icon-Italic", hint: DevExpress.Analytics.Utils.getLocalization("Italic", "System.Drawing.Font.Italic") },
                                                            { actionType: "Button", command: "ToggleFontUnderline", icon: " dxre-icon-Underline", hint: DevExpress.Analytics.Utils.getLocalization("Underline", "System.Drawing.Font.Underline") },
                                                            { actionType: "Button", command: "ToggleFontStrikeout", icon: " dxre-icon-Strikeout", hint: DevExpress.Analytics.Utils.getLocalization("Strikeout", "System.Drawing.Font.Strikeout") }
                                                        ]
                                                    },
                                                    { id: RichEdit.ToolbarActionId.ToggleCaseButton, actionType: "Button", command: "ToggleTextCase", icon: " dxre-icon-ChangeTextCase", hint: DevExpress.Analytics.Utils.getLocalization("tOGGLE cASE", "XtraRichEditStringId.MenuCmd_ToggleTextCase") }
                                                ]
                                            },
                                            {
                                                id: RichEdit.ToolbarGroupId.FontSize,
                                                title: DevExpress.Analytics.Utils.getLocalization("Font Size", "XtraRichEditStringId.MenuCmd_ChangeFontSize"),
                                                items: [{ id: RichEdit.ToolbarActionId.FontSizeComboBox, actionType: "ComboBox", command: "ChangeFontSize", items: [8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 26, 28, 36, 48, 72] }],
                                            },
                                            {
                                                id: RichEdit.ToolbarGroupId.Font,
                                                title: DevExpress.Analytics.Utils.getLocalization("Font", "XtraRichEditStringId.MenuCmd_ChangeFontName"),
                                                items: [{ id: RichEdit.ToolbarActionId.FontComboBox, actionType: "ComboBox", command: "ChangeFontName", items: fonts }],
                                            },
                                            {
                                                id: RichEdit.ToolbarGroupId.FontColor,
                                                title: DevExpress.Analytics.Utils.getLocalization("Font Color", "XtraRichEditStringId.MenuCmd_ChangeFontColor"),
                                                items: [{ id: RichEdit.ToolbarActionId.FontColorBox, actionType: "ColorBox", command: "ChangeFontForeColor", defaultValue: "rgb(0, 0, 0)" }],
                                            },
                                            {
                                                id: RichEdit.ToolbarGroupId.BackgroundColor,
                                                title: DevExpress.Analytics.Utils.getLocalization("Background Color", "DevExpress.XtraReports.UI.XRRichTextBoxBase.BackColor"),
                                                items: [{ id: RichEdit.ToolbarActionId.BackgroundColorBox, actionType: "ColorBox", command: "ChangeFontBackColor", defaultValue: "rgb(255, 255, 255)" }]
                                            }
                                        ];
                                    };
                                    _this.onSelectionChanged = function (sender, args) {
                                        _this.componentCollection.forEach(function (group) { return (group.items || []).forEach(function (item) { return item._updateStateInternal && item._updateStateInternal(); }); });
                                    };
                                    _this.onContentReady = _this._popover.onContentReady;
                                    _this.getPositionTarget = function (element) {
                                        return $(element).closest("." + _this.parentClass).closest(".dxrd-control")[0];
                                    };
                                    _this.closeOnOutsideClick = function (e) {
                                        if (_this._popover.closeOnOutsideClick(e)) {
                                            _this.visible(false);
                                            return false;
                                        }
                                        return true;
                                    };
                                    _this.template = "dxrd-richedit-toolbar";
                                    _this.parentClass = "dxrd-rich-surface";
                                    _this.getPopupContainer = DevExpress.Analytics.Internal.getParentContainer;
                                    _this.componentCollection = [];
                                    _this.visible = options.visible;
                                    var commandOptions = {
                                        commandManager: options.commandManager,
                                        executeCommand: options.executeCommand,
                                        richEditPublic: options.richEditPublic
                                    };
                                    var toolbarItems = DevExpress.Analytics.Internal.extend(true, [], _this._getDefaultItems(options.richEditPublic.document.fonts.getAllFontNames()));
                                    var getById = function (itemId) {
                                        var matchedItem;
                                        var group = toolbarItems.filter(function (item) {
                                            if (matchedItem)
                                                return false;
                                            if (item.id === itemId)
                                                return true;
                                            matchedItem = item.items.filter(function (x) { return x.id === itemId; })[0];
                                        })[0];
                                        return matchedItem || group;
                                    };
                                    RichEdit.events.call("customizeToolbarActions", { actions: toolbarItems, getById: getById });
                                    _this.componentCollection = _this._initComponents(toolbarItems, commandOptions, true);
                                    if ((_this.componentCollection || []).every(function (component) { return !component.visible; }))
                                        _this.visible = ko.observable(false);
                                    return _this;
                                }
                                ToolbarSurface.prototype._initComponents = function (items, options, root) {
                                    var _this = this;
                                    if (root === void 0) { root = false; }
                                    return items.map(function (item) {
                                        var component;
                                        if (root) {
                                            component = new ComponentCollection(item.id, item.title, item.visible, item.template);
                                            component.items = _this._initComponents(item.items, options);
                                        }
                                        else {
                                            switch (item.actionType) {
                                                case "ButtonGroup":
                                                    component = item.id === RichEdit.ToolbarActionId.ParagraphAlignmentButtonGroup ? new ComponentTextAligment(options, item) : new ComponentButtonGroup(options, item);
                                                    break;
                                                case "Button":
                                                    component = new ComponentButton(options, item);
                                                    break;
                                                case "ComboBox":
                                                    component = item.id === RichEdit.ToolbarActionId.FontSizeComboBox ? new ComponentFontSizeComboBox(options, item) : new ComponentComboBox(options, item);
                                                    break;
                                                case "ColorBox":
                                                    component = new ComponentColorPicker(options, item);
                                                    break;
                                                default:
                                                    component = new CustomComponent(options, item);
                                            }
                                        }
                                        return _this._extendTemplateOptions(item, component);
                                    });
                                };
                                ToolbarSurface.prototype._extendTemplateOptions = function (item, el) {
                                    if (item.template)
                                        return DevExpress.Analytics.Internal.extend(true, {}, el, item);
                                    return el;
                                };
                                return ToolbarSurface;
                            }(DevExpress.Analytics.Utils.Disposable));
                            Toolbar.ToolbarSurface = ToolbarSurface;
                        })(Toolbar = Internal.Toolbar || (Internal.Toolbar = {}));
                        var RichEditLoadDispatcher = (function (_super) {
                            __extends(RichEditLoadDispatcher, _super);
                            function RichEditLoadDispatcher(richEdit) {
                                var _this = _super.call(this) || this;
                                _this.richEdit = richEdit;
                                return _this;
                            }
                            RichEditLoadDispatcher.prototype.process = function (element) {
                                if (element.queueAction === RichAction.OpenDocument) {
                                    this.richEdit.openDocumentNative(element.base64, element.documentFormat, function () {
                                        element.ready();
                                    }, function () {
                                        if (element.errorCallBack)
                                            element.errorCallBack();
                                    });
                                }
                                if (element.queueAction == RichAction.NewDocument) {
                                    this.richEdit.newDocumentNative(function () {
                                        element.ready();
                                    });
                                }
                                if (element.queueAction == RichAction.SaveDocument) {
                                    this.richEdit.saveDocumentNative(element.documentFormat, function (result) {
                                        if (element.documentConverted)
                                            element.documentConverted(result);
                                    });
                                }
                            };
                            return RichEditLoadDispatcher;
                        }(DevExpress.Analytics.Utils.Disposable));
                        Internal.RichEditLoadDispatcher = RichEditLoadDispatcher;
                    })(Internal = RichEdit.Internal || (RichEdit.Internal = {}));
                })(RichEdit = Controls.RichEdit || (Controls.RichEdit = {}));
                var XRRichModernSurface = (function (_super) {
                    __extends(XRRichModernSurface, _super);
                    function XRRichModernSurface(control, context) {
                        var _this = _super.call(this, control, context) || this;
                        _this.isValid = ko.observable(true);
                        _this.serializedRtf = ko.observable("");
                        _this.template = "dxrd-richedit";
                        _this.contenttemplate = "dxrd-richedit-content";
                        _this.selectiontemplate = "dxrd-richedit-selection";
                        _this._convertReady = $.Deferred();
                        DevExpress.Reporting.Designer.Utils.base64UTF16LEtobase64UTF8(control.serializableRtfString(), function (val) {
                            _this.serializedRtf(val);
                            _this._convertReady.resolve(true);
                        });
                        _this._disposables.push(_this.serializedRtf.subscribe(function (newValue) {
                            control.serializableRtfString(newValue);
                        }));
                        _this.defaultStyleunit = ko.computed(function () { return ({
                            top: _this.contentSizes().top + (_this.isIntersect() ? 1 : 0),
                            left: _this.contentSizes().left + (_this.isIntersect() ? 1 : 0),
                            lineHeight: _this.contentSizes().height,
                            height: _this.contentSizes().height,
                            width: _this.contentSizes().width
                        }); }).extend({ deferred: true });
                        _this._disposables.push(_this.defaultStyleunit);
                        return _this;
                    }
                    XRRichModernSurface.prototype.createController = function (richEdit) {
                        var _this = this;
                        this._convertReady.done(function () {
                            _this.controller = new RichEdit.Internal.XRRichController(richEdit, _this);
                            _this._disposables.push(_this.controller);
                        });
                    };
                    return XRRichModernSurface;
                }(Controls.XRControlSurface));
                Controls.XRRichModernSurface = XRRichModernSurface;
                (function (RichEdit) {
                    RichEdit.ToolbarActionId = {
                        ParagraphAlignmentButtonGroup: "dxxrta-buttongroup-paragraph-alignment",
                        HyperlinkButton: "dxxrta-button-hyperlink",
                        ClearFormattingButton: "dxxrta-button-clear-formatting",
                        FontStyleButtonGroup: "dxxrta-buttongroup-toggle-font",
                        ToggleCaseButton: "dxxrta-button-text-case",
                        FontSizeComboBox: "dxxrta-combobox-text-size",
                        FontComboBox: "dxxrta-combobox-font",
                        FontColorBox: "dxxrta-colorbox-font",
                        BackgroundColorBox: "dxxrta-colorbox-background",
                    };
                    RichEdit.ToolbarGroupId = {
                        AlignmentAndFormatting: "dxxrtg-buttons-first",
                        FontStyleAndCase: "dxxrtg-buttons-second",
                        FontSize: "dxxrtg-font-size",
                        Font: "dxxrtg-font-family",
                        FontColor: "dxxrtg-text-color",
                        BackgroundColor: "dxxrtg-back-color",
                    };
                    RichEdit.events = new DevExpress.Analytics.Utils.EventManager();
                    RichEdit.getRichEditSurface = function () { return !!DevExpress.RichEdit ? XRRichModernSurface : Controls.XRRichSurface; };
                    RichEdit.registerRichEditInline = function (selection) { return !!DevExpress.RichEdit && new Controls.RichEdit.Internal.InlineRichEditControl(selection); };
                })(RichEdit = Controls.RichEdit || (Controls.RichEdit = {}));
            })(Controls = Designer.Controls || (Designer.Controls = {}));
        })(Designer = Reporting.Designer || (Reporting.Designer = {}));
    })(Reporting = DevExpress.Reporting || (DevExpress.Reporting = {}));
})(DevExpress || (DevExpress = {}));
DevExpress.Analytics.Widgets.Internal.SvgTemplatesEngine.addTemplates({
    'dxrd-rich-edit': '<div style="width:100%; height: 100%" data-bind="css: className">        <div data-bind="visible: visible">            <!-- ko with: getToolbar() -->            <!-- ko template: { name: template, data: $data }-->            <!-- /ko -->            <!-- /ko -->        </div>    </div>',
    'dxrd-richedit-toolbar': '<div style="z-index: 0; position: absolute;" data-bind="dxPopover: {        width: \'auto\',        height: \'auto\',        position: { my: \'right center\', at: \'left center\', boundary: \'.dxrd-designer-wrapper\', of: getPositionTarget($element), collision: \'flip fit\', offset: \'-10 0\' },        container: getPopupContainer($element),        onContentReady: onContentReady,        closeOnOutsideClick: closeOnOutsideClick,        showTitle: false,        target: getPositionTarget($element),        showCloseButton: false,        shading: false,        visible: visible,        animation: {} }">        <div class="dxrd-rich-toolbar-popover-content">            <!-- ko foreach: componentCollection -->            <!-- ko if: $data.visible -->            <!-- ko template: { name: $data.template, data: $data } -->            <!-- /ko -->            <!-- /ko -->            <!-- /ko -->        </div>    </div>',
    'dxrd-rich-edit-toolbar-component-collection': '<div class="dxrd-toolbar-elements-line">        <!-- ko if: $index() !== 0 -->        <div class="dxrd-toolbar-elements-line-bottom dxd-border-secondary"></div>        <!-- /ko -->        <!-- ko if: $data.showTitle() -->        <div class="dxrd-rich-toolbar-header" data-bind="text: $data.showTitle();"></div>        <!-- /ko -->        <div class="dxrd-rich-toolbar-value">            <!-- ko foreach: { data: $data.items } -->            <!-- ko if: $data.visible -->            <!-- ko template: { name: $data.template, data: $data } -->            <!-- /ko -->            <!-- /ko -->            <!-- /ko -->        </div>    </div>',
    'dxrd-rich-edit-toolbar-button-group': '<div data-bind="dxButtonGroup:{ items: items, keyExpr: itemKey, selectedItems: selectedItems, selectionMode: selectionMode, stylingMode: \'text\', focusStateEnabled: false}"></div>',
    'dxrd-button-with-template': '<div data-bind="dxButton: { onClick: $data.clickAction, icon: $data.icon, hint: $data.hint, stylingMode: \'text\', focusStateEnabled: false }"></div>',
    'dxrd-richEdit-toolbar-colorpicker': '<div data-bind="dxColorBox: { value: value, popupPosition: { collision: \'flipfit flipfit\' }, focusStateEnabled: false }"></div>',
    'dxrd-rich-toolbar-combobox': '<div data-bind="dxLocalizedSelectBox: { dataSource: items, value: value, focusStateEnabled: false, searchEnabled: !supportCustomValue, displayCustomValue: true,  acceptCustomValue: supportCustomValue, openOnFieldClick: !supportCustomValue }, dxValidator: { validationRules: validationRules }"></div>',
    'dxrd-richedit-content': '<div data-bind="css:{ \'dxrd-intersect\': !isValid() }" style="box-sizing: border-box; letter-spacing: normal; width:100%; height: 100%">    <div data-bind="style: { display: isValid()? \'inline\' : \'none\' }">        <div style="width:100%; height: 100%; vertical-align: top;" class="dxrd-control-content dxrd-richedit-readonly" data-bind="style: contentCss"></div>    </div>    <!-- ko if: !isValid() -->    <div data-bind="text: \'Document is not valid\'"></div>    <!-- /ko --></div>',
    'dxrd-richedit-selection': '<div class="dxrd-control" data-bind="event: { dblclick: function() { $root.richInlineControl.show($element) } }, visible: selected() || focused(), css: {\'dxrd-selected\': selected, \'dxrd-focused\': focused, \'dxrd-intersect\': isIntersect, \'dxrd-locked\': locked }, resizable: $root.resizeHandler, draggable: $root.dragHandler, styleunit: position, trackCursor: underCursor">    <!-- ko if: selected() -->    <div class="dxd-border-accented dxrd-control-border-box" data-bind="style: { \'backgroundColor\': $root.richInlineControl.visible() && selected() ? \'#FFF\' : \'transparent\' }"></div>    <!-- /ko --></div><div class="dxrd-control" data-bind="visible: !(selected() && focused()), styleunit: position, trackCursor: underCursor, style:{ overflow: isSelected() ? \'visible\' : \'hidden\'}">    <div class="dxrd-control-content-select-main" data-bind="styleunit: { \'top\': contentSizes().top + (isIntersect() ? 1 : 0), \'left\': contentSizes().left + (isIntersect()? 1 : 0), lineHeight: contentSizes().height, height: contentSizes().height, width: contentSizes().width}">    </div></div><div class="dxrd-control dxrd-richedit-selected" data-bind="styleunit: position, trackCursor: underCursor, style:{ pointerEvents: $root.richInlineControl.visible() && selected() ? \'auto\' : \'none\'  }">    <div class="dxrd-control-content-main" data-bind="styleunit: defaultStyleunit">        <div class="dxrd-richedit-selected-content" data-bind="zoom: _context.zoom(), styleunit: { \'height\': contentHeightWithoutZoom, \'width\': contentWidthWithoutZoom }, dxRichSurface: { inlineEdit: $root.richInlineControl }">        </div>    </div></div>',
});
