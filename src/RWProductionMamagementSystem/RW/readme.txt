核心库说明：

近期升级计划：

更新日志：
2017-11-08 1.6.23.80 - 1.6.23.81
1、新增了自检UI接口与方法。
2、增加非空逻辑判断。

2017-10-24 1.6.22.79
1、增加CSV文件读写功能。

2017-10-16 1.6.21.76 - 1.6.21.78
1、修复LoadConfig可能为空的问题。
2、调整事件记录使用异步记录的功能。
3、增加事件记录行为时加锁，防止写入文件冲突。

2017-10-16 1.6.21.75
1、IniConfig新增了通用配置方法。

2017-10-13 1.6.20.74
1、调整了风量单位为mmmpmin

2017-10-12 1.6.20.73
1、新增了风量单位，mmms;

2017-10-11 1.6.20.72
1、BaseProcedure底层类新增了Collect按模块的方法。

2017-10-09 1.6.20.71
1、增加自检底层功能代码。

2017-10-08 1.5.20.69 - 1.5.20.70
1、新增了事件日志功能，暂时保存文本文件。
2、事件日志功能新增了查询功能，完善了清空和删除操作。

2017-10-08 1.4.20.69
1、IniFile类新增了移除Key和Section的方法。

2017-09-28 1.4.20.68
1、Hardware模块重写了ToString方法。用于快速调试和快速显示。

2017-09-26 1.4.20.67
1、新增了语音功能，使用系统语音自动发音（TTS）。

2017-09-26 1.3.19.66
1、BaseResult新增了多结果的委托，用于支持多结果。

2017-09-25 1.3.19.65
1、优化了BaseProcedure的OnTicked方法时，触发器不是从t=0开始。

2017-09-18 1.3.19.64
1、修复通用数字量事件在opc为float，代码为double类型时，导致数据转换精度的问题。

2017-09-16 1.3.19.63
1、ControlHelper新增了按钮动作时间，在动作时间内不会将按钮变灰。

2017-09-12 1.3.19.62
1、调整了DataHelper中Genator的调用（已标记了过时）

2017-09-11 1.3.19.61
1、BaseProcedure类标记了“Model”过期，不建议再使用此属性。

2017-09-08 1.3.19.59 - 1.3.19.60
1、BaseModule自动支持了模拟量和数字量的分类管理，并支持了数据触发。可以使用UI进行关联。
2、新增了IAnalogValueEvent与IDigitalValueEvent接口，并在BaseModule中实现。

2017-09-07 1.2.18.58
1、新增了IConfig接口，用于描述可配置的接口类。
2、BaseConfig调整到IniConfig。BaseConfig已标记过时。         ******警告：BaseConfig已过时，请使用IniConfig或IConfig******

2017-09-06 1.2.17.56
1、修改HardWare为Hardware，命名更合理。而HardWare暂时标记为已过时。       ******警告：请注意名称的变更******

2017-08-31 1.2.17.55
1、BaseInputGroup的Pre属性默认值调整，设计时，不会自动添加到代码中。
2、BaseResult新增了带参数的初始化方法。

2017-08-25 1.2.17.50 - 1.2.17.53
1、BaseProcedure新增了OnTicked(TimeSpan ts)方法。
2、由于命名空间定义错误，修改了命名空间“Proceduce”到“Procedure”。              **********[重要修改，请主要名称变更]**********
3、BaseModules脉冲写增加延时功能。
4、优化了BaseTestBed的Scram事件触发模式。

2017-08-22 1.2.16.48 - 1.2.16.49
1、修复BaseTestBed可能不触发ScramChanged事件的问题。
2、BaseProcedure的Testing属性增加默认值功能。

2017-08-18 1.2.16.45 - 1.2.16.47
1、IDBBase新增了Connect接口。
2、ControlHelper支持了错误回调函数。
3、FileLog的文件名默认初始化在根目录的log文件夹log.txt文件。

2017-08-16 1.2.16.44
1、BaseProcedure类将onTestingChang调整为了OnTestingChang，大小写，更符合设计规范。         ******请注意改名******

2017-08-07 1.2.16.43
1、修复BaseSensorGroup由于mapped映射关系不存在导致报错的问题。

2017-08-01 1.2.16.42
1、修复BaseProcedure中OnTicked时，超时时返回False，并且新增了TimeSpan的方式。

2017-07-19 1.2.16.41
1、修复Modbus通讯高低字节的一些问题。

2017-07-17 1.2.16.40
1、BaseConfig继续扩展，新增了获取属性以及设置的功能。SectionName改为public，允许外部调用。

2017-07-14 1.2.15.39
1、BaseConfig新增了几个特性类，用于在反射时使用中文名读写。

2017-07-12 1.2.14.38
1、BaseConfig新增了SetSectionName，保存ini文件时，允许指定SectionName。

2017-07-10 1.2.13.37
1、新增了位图灰度处理以及二值化处理。

2017-07-07 1.2.12.36
1、修复BaseConfig在保存时，目录不存在无法保存的问题。现在会自动创建目录。

2017-07-04 1.2.11.35
1、新增了MD5Helper方法，用于MD5加密。
2、新增了SerialPortConfig类，用于储存SerialPort参数。
3、SerialPort类扩展了使用SerialPortConfig类初始化。
4、BaseConfig修复枚举无法反序列化的问题。
5、BaseConfig新增了SetFilename方法，可实时设置文件名。
6、BaseConfig新增了指定文件名加载以及保存的方法。
7、修复了ModbusSerialPort类读写寄存器高低位错误的问题。

2017-06-27 1.2.8.28
1、修复Modbus的CRC校验失败的问题。

2017-06-26 1.2.8.27
1、GetBitmap方法调整，获取图片位置功能。

2017-06-23 1.2.8.26
1、新增了获取控件的Bitmap，方便保存或其他处理的功能。

2017-06-22 1.2.7.25
1、新增发送串口命令Debug内容，方便调试。
1、新增ModbusConfig配置功能。（暂未启用）

2017-06-21 1.2.6.22
1、Modbus协议新增了02命令，读取输入线圈。
2、修复BaseConfig字符串序列化和反序列化的问题。

2017-06-19 1.2.5.20
1、优化了BaseTestBed处理scramChanged事件多次触发的问题，减少了事件触发量。
2、修复了可能导致设计时初始化的问题。

2017-06-15 1.2.5.19
1、完善了Modbus驱动，预计开发PCIDriver驱动功能。
5.20、BaseTestBed的Scram属性修改为protected，允许子类进行修改，移除了PCIDriver类。

2017-06-13 1.2.4.18
1、BaseProcedure过程基类新增了OnTick的重载，可支持稳压和保压的试验。

2017-06-12 1.2.4.17
1、配置文件基类增加了一些描述说明。

2017-06-10 1.2.4.14
1、简化了OPCDriver中，读取和写入操作重复的问题，现在调用相同的方法。Read以及Write。
2、修复了一个可能导致多次初始化的问题。
3、修复了ModuleGroup控件不会自动初始化的问题。

2017-06-08 1.2.4.13
1、属性还是按照vs2005的完整写法，简写方式暂不使用。

2017-06-06 1.2.4.10
4.10、BaseConfig不再判断使用如何解析，完全使用ISerializer进行解析。
4.11、调整了ISerializer接口，在反序列化时，使用传入类型参数。
4.12、BaseConfig增加判断值类型则直接写入，不走ISerializer接口。

2017-06-05 1.2.4.9
1、修复OPCDriver的构造函数中，三个参数的构造IP未初始化问题。
2、新增了使用OPCConfig进行初始化OPCDriver。

2017-06-02 1.2.4.7
1、BaseTestBed新增了触发事件的方法。

2017-06-01 1.2.4.6
1、新增了SecurityHelper类，用于Md5等加密算法。

2017-05-25 1.2.4.5
1、修复BaseDIGroup的命名空间错误的问题。

2017-05-24 1.2.4.4
1、ModbusDriver新增了Port属性，用于获取ModbusSerialPort的实例，因为Driver目前并没有实现。
2、ModbusSerialPort类修改了Write和Read方法，使用寄存器和线圈两个名词，如：WriteRegister,ReadCoil
3、优化了BaseAIGroup与BaseDIGroup操作类。
4、在考虑是否需要移除BaseAIGroup使用BaseAnalog替代。BaseDIGroup使用BaseDigital替代。

2017-05-23 1.2.4.1
1、新增了ModbusDriver以及ModbusSerialPort，用于支持Modbus协议。
2、目前实现了modbus协议中的01,05,15,03,06,16这些指令集。（待测试）

2017-05-18 1.2.3.1
1、新增BaseAIGroup、BaseAOGroup、BaseInputGroup组件。详细可见架构设计Visio图。
2、BaseSensorGroup不再继承自BaseModule,继承自BaseInputGroup组件，用于支持所有DI、DO、AI、AO。
注意：此次的改动目前未经过测试，可能导致不可预料的问题。

2017-05-18 1.2.2.3
1、扩展了IValue接口，接口泛型化，默认double；
2、新增了UnitEnum的3个类型，并增加了支持的帮助类，UnitHelper用于获取Unit对应的字符串单位。

2017-05-16 1.2.2.2
1、新增了IValue的接口声明，并应用到项目中。
2、新增了IValueIndex接口，用于包含所引器的值，是否与IIndexes冲突，有待验证。

2017-05-15 1.2.2.1
1、BaseModule新增了InitComponts方法，用于构造时初始化。
2、UnitEnums新增了3个单位，g，kg，t分别表示克，千克，吨。
3、IIndex拆分成IIndexes用于属性获取，IIndexFiled包含Index字段。

2017-05-12 1.2.1.3
1、Hardware中，调整了零点增益的计算，实际值=工程值*增益值-零点值
2、BaseModule的Init中增加了Driver为null的判断，避免报错时无法找出原因。
3、预计增加BaseSensorArray类，用于处理数组的值，使用时存在一些问题。
4、BaseSensorGroup类优化，未使用mapped时，会自动初始化。

2017-05-10 1.2.1.1
1、新增了OleDB按文本生成sql的方法。

2017-05-08 1.2.0.15
1、调整了OPCDriver中的key选择方式，当设置了Prefix时，无需调用getfullkey。
2、新增了HardwareList类，用于描述数组。
3、

2017-05-03 1.2.0.14
1、调整了HardwareGroup，以及BaseSensorGroup中的调用，避免重写Hardware时报错。

2017-05-02 1.2.0.13
1、新增了均方根的计算公式，在RWCal中。

2017-04-27 1.2.0.11
1、新增了IDriver接口，用于描述OPCDriver。
2、新增了SerialPortDriver以及ModbusDriver用于用于串口通讯的协议。
3、新增了TCPDriver与PCIDriver用于描述网线通讯以及PCI通讯。

2017-04-26 1.2.0.10
1、IClickable接口文件提出。
2、新增了INumberical接口，用于描述数值带单位的控件。

2017-04-25 1.2.0.9
1、模块层更新，支持通道号。使用映射关系。
2、Hardware数组使用对象方式。

2017-04-21 1.2.0.8
1、UnitEnum从RW.UI.Controls库中移动到RW库中。

2017-04-19 1.2.0.7
1、JSON.NET序列化接口化，使得Hareware不再依赖于Newtosoft包。
2、新增了LogFactory，为日志记录做准备。
6.1、新增了ModuleGroup组件，该组件可以初始化页面的所有基于BaseModule的组件。
6.2、OPCDriver优化使用，新增了Write方法针对Key名称以及同步和异步Write，和配套的Read操作。
7.1、新增了IProcedure接口，用于描述过程的接口声明。

2017-04-18 1.2.0.4
1、新增了ISwitch接口以及附属的ISwitchColor及ISwitchImage接口，用于描述状态切换的功能。
2、新增了IClickable、IAsyncClick接口，用于描述控件是否可点击以及异步点击状态。
4.1、IInit接口，新增InitError事件，用于Init报错后触发该事件。

2017-04-15 1.2.0.2
1、增加了一些接口，部分类成员接口化。IGroupIndex，IInit，IGain，IGainGroup
2、新增了类结构图，用于方便模块化结构。

2017-04-13 1.2.0.1
1、振动传感器对应的模块，新增是否需要在本地计算灵敏度值。（因为仪表中已经计算过，本地再次计算会导致数据不一致问题。）
2、类结构做了一次比较大的调整，主要在于基类与接口的重新定义，可能影响范围比较大，请按照以下方式调整：
	1>BaseReadModule类暂时取消，请使用BaseSensor类（过期标记，并为完全移除）。
	2>Sensor类更名为BaseSensor，由于直接更名，导致之前的引用会报错，请直接更名。
	3>IGain接口重新更名为IHardware接口，并且新增了Value属性和几个事件，请注意。
	4>BaseModule中，对于初始化提出了IInit接口，之前的使用不会有问题，但使用方法更加便捷。
	5>新增了SensorGroup类的基类，BaseSensorGroup如果有使用SensorGroup请使用BaseSensorGroup类，此类描述更加合理，并方便使用。
	6>新增了IIndex接口，用于描述包含索引的类，如BaseSensorGroup中使用，获取UCCalibration中同样也使用了。
本次调整的结构过大，主要针对接口分离，特此升级大版本为1.2

2017-04-10 1.1.0.22
1、BaseModule新增通过Key获取或者设置值的功能。
2、HardWare模块增加本地与设置计算方式的功能，默认本地计算，设置零点增益，Value自动变更。
3、ControlHelper在调用Invoke时，增加了条件判断，防止了出错的发生。

2017-04-05 1.1.0.21
1、修复BaseModule动态调用时类型错误的问题。
2、ADOX类引用本地文件。
3、BaseModule新增脉冲写入的功能。

2017-04-01 1.1.0.20
1、修复不自动生成数据库的问题。
2、BaseModule检测信号功能扩展。

2017-03-31 1.1.0.18
1、OPCDriver支持IP的构造方式。
2、BaseModule的Prefix变量，不再自动追加“.”，请注意此次更新。

2017-03-27 1.1.0.17
1、OPC驱动增加IP的控制。
2、BaseOPC修改为Prefix更合理。

2017-03-22 1.1.0.16
1、修复未使用dbTemplate的项目Login不显示的问题。
2、修复硬件通讯不上导致写入零点增益超时的问题（值类型不需要超时）。
3、重新替换了新的Newtonsoft.json文件。

2017-03-20 1.1.0.15
1、修复OPCDrvier多次连接导致不触发事件的问题。
2、修复修改系统语言，会修改当前本地语言

2017-03-16 1.1.0.14
1、优化数据库自动生成方式，允许使用sql语句在代码直接生成。
2、新增了自动生成sqlite的功能。

2017-03-15 1.1.0.13
1、BaseModule调用写入时，会自动检测点是否真实写入，默认检测，可不检测调用。
2、BaseModule报错信息优化。

2017-03-08 1.1.0.12
1、修复SQL生成器会删除文件的问题，导致安装包重新安装。
2、修复退出时，Close会报错的问题。

2017-03-04 1.1.0.11
1、支持振动传感器模块灵敏度设置。

2017-03-01 1.1.0.10
1、取消ControlHelper会提示所有的错误信息功能；
2、BaseModule完善，移除掉一些无用的类。

2017-02-27 1.1.0.8
1、BaseResult新增SetResult方法；
2、OleDB新增CreateDatabase方法；
3、新增OleDB辅助方法生成数据库；

2017-02-23 1.1.0.7
1、修复试验过程基类中OnXXX的基类方法不调用的问题；

2017-02-18 1.1.0.6
(重要修复)修复OPC类型为float的变量，转换成double时的精度问题；

2017-02-07 1.1.0.5
Procedure通用

2017-01-19 1.1.0.4
ControlHelper移动到该类库中，作为全局通用;

2017-01-17 1.1.0.3
BaseReadModule类，增加on触发事件。
部分float类型改成double；

2017-01-17 1.1.0.2
OPC驱动调整，优化驱动逻辑，方便捕捉错误。

2017-01-17 1.1.0.1
新增readme文件，用于以后的更新日志；