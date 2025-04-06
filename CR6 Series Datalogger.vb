'CR6 Series Datalogger
'To create a different opening program template, type in new
'instructions and select Template | Save as Default Template
'date:
'program author:

'Declare Constants
'Example:
'CONST PI = 3.141592654 or Const PI = 4*ATN(1)

'Declare Public Variables
'Example:
Const Samsung_Port=502
Const Samsung_Addr="192.168.100.50"
Public Modbus_warranty(9) As Float
Public Modbus_warranty_external(3) As Float
Public Modbus_qdca(19) As Float
Public Modbus_Blocos_A_B(19) As Float
Public Modbus_Bloco_C(19) As Float
Public Modbus_Carr_eBus(19) As Float
Public Modbus_FV_Blocos_A_B(19) As Float
Public Modbus_PCS(19) As Float
Public Modbus_PCS_real(52) As Float
Public Modbus_FV_BLOC_C(19) As Float
Public Modbus_BAT_2_VIDA(19) As Float
Public Modbus_RESERVA(19) As Float

Public Modbus_BAT_2_VIDA_1(14) As Long
Public Modbus_BAT_2_VIDA_2(15) As Long
Public Modbus_BAT_2_VIDA_3(17) As Float

Public Samsung_Handle As Long
Public Socket As Long
Public Result As Long

Alias Modbus_BAT_2_VIDA_1(2)= MRR_BMS1_T
Alias Modbus_BAT_2_VIDA_1(3)= MRR_BMS1_TMIN
Alias Modbus_BAT_2_VIDA_1(4)= MRR_BMS1_TMAX
Alias Modbus_BAT_2_VIDA_1(5)= MRR_BMS1_VMIN_N
Alias Modbus_BAT_2_VIDA_1(6)= MRR_BMS1_VMAX_N
Alias Modbus_BAT_2_VIDA_1(7)= MRR_BMS1_RMIN_N
Alias Modbus_BAT_2_VIDA_1(8)= MRR_BMS1_RMAX_N
Alias Modbus_BAT_2_VIDA_1(9)= MRR_BMS1_TMIN_N
Alias Modbus_BAT_2_VIDA_1(10)= MRR_BMS1_TMAX_N
Alias Modbus_BAT_2_VIDA_1(11)= MRR_BMS1_SOH
Alias Modbus_BAT_2_VIDA_1(12)= MRR_BMS1_SOC
Alias Modbus_BAT_2_VIDA_1(13)= MRR_BMS1_CHARGE_LIM
Alias Modbus_BAT_2_VIDA_1(14)= MRR_BMS1_DISCHARGE_LIM

Alias Modbus_BAT_2_VIDA_2(2)= MRR_BMS2_T
Alias Modbus_BAT_2_VIDA_2(3)= MRR_BMS2_TMIN
Alias Modbus_BAT_2_VIDA_2(4)= MRR_BMS2_TMAX
Alias Modbus_BAT_2_VIDA_2(5)= MRR_BMS2_VMIN_N
Alias Modbus_BAT_2_VIDA_2(6)= MRR_BMS2_VMAX_N
Alias Modbus_BAT_2_VIDA_2(7)= MRR_BMS2_RMIN_N
Alias Modbus_BAT_2_VIDA_2(8)= MRR_BMS2_RMAX_N
Alias Modbus_BAT_2_VIDA_2(9)= MRR_BMS2_TMIN_N
Alias Modbus_BAT_2_VIDA_2(10)= MRR_BMS2_TMAX_N
Alias Modbus_BAT_2_VIDA_2(11)= MRR_BMS2_SOH
Alias Modbus_BAT_2_VIDA_2(12)= MRR_BMS2_SOC
Alias Modbus_BAT_2_VIDA_2(13)= MRR_BMS2_CHARGE_LIM
Alias Modbus_BAT_2_VIDA_2(14)= MRR_BMS2_DISCHARGE_LIM
Alias Modbus_BAT_2_VIDA_2(15)= MRR_SOC_MEDIO

Alias Modbus_BAT_2_VIDA_3(2)= MRR_BMS_VDC_TOTAL
Alias Modbus_BAT_2_VIDA_3(3)= MRR_BMS_IDC_TOTAL
Alias Modbus_BAT_2_VIDA_3(4)= MRR_BMS1_VDC
Alias Modbus_BAT_2_VIDA_3(5)= MRR_BMS1_IDC
Alias Modbus_BAT_2_VIDA_3(6)= MRR_BMS1_R
Alias Modbus_BAT_2_VIDA_3(7)= MRR_BMS1_VMIN
Alias Modbus_BAT_2_VIDA_3(8)= MRR_BMS1_VMAX
Alias Modbus_BAT_2_VIDA_3(9)= MRR_BMS1_RMIN
Alias Modbus_BAT_2_VIDA_3(10)= MRR_BMS1_RMAX
Alias Modbus_BAT_2_VIDA_3(11)= MRR_BMS2_VDC
Alias Modbus_BAT_2_VIDA_3(12)= MRR_BMS2_IDC
Alias Modbus_BAT_2_VIDA_3(13)= MRR_BMS2_R
Alias Modbus_BAT_2_VIDA_3(14)= MRR_BMS2_VMIN
Alias Modbus_BAT_2_VIDA_3(15)= MRR_BMS2_VMAX
Alias Modbus_BAT_2_VIDA_3(16)= MRR_BMS2_RMIN
Alias Modbus_BAT_2_VIDA_3(17)= MRR_BMS2_RMAX

Alias Modbus_warranty(1)= Dummy
Alias Modbus_warranty(2)= Tensao_Saida_BMS
Alias Modbus_warranty(3)= Corrente_Saida_BMS
Alias Modbus_warranty(4)= SOC_BMS
Alias Modbus_warranty(5)= SOH_BMS
Alias Modbus_warranty(6)= Tensao_Max_Cels_BMS
Alias Modbus_warranty(7)= Tensao_Min_Cels_BMS
Alias Modbus_warranty(8)= Temp_Max_Cels_BMS
Alias Modbus_warranty(9)= Temp_Min_Cels_BMS

Alias Modbus_warranty_external(2) = Umidade_Relativa_Container
Alias Modbus_warranty_external(3) = Temp_Container

Alias Modbus_qdca(2)= Tensao_Fase_Media_QDCA
Alias Modbus_qdca(3)= Tensao_Fase_A_QDCA
Alias Modbus_qdca(4)= Tensao_Fase_B_QDCA
Alias Modbus_qdca(5)= Tensao_Fase_C_QDCA
Alias Modbus_qdca(6)= Corrente_Fase_Media_QDCA
Alias Modbus_qdca(7)= Corrente_Fase_A_QDCA
Alias Modbus_qdca(8)= Corrente_Fase_B_QDCA
Alias Modbus_qdca(9)= Corrente_Fase_C_QDCA
Alias Modbus_qdca(10)= Tensao_Linha_Media_QDCA
Alias Modbus_qdca(11)= Tensao_Linha_A_QDCA
Alias Modbus_qdca(12)= Tensao_Linha_B_QDCA
Alias Modbus_qdca(13)= Tensao_Linha_C_QDCA
Alias Modbus_qdca(14) = FP_QDCA
Alias Modbus_qdca(15)= Potencia_Util_QDCA
Alias Modbus_qdca(16)= Potencia_Reativo_QDCA
Alias Modbus_qdca(17)= Potencia_Aparente_QDCA
Alias Modbus_qdca(18)= Frequencia_QDCA
Alias Modbus_qdca(19)= Corrente_Neutro_QDCA

Alias Modbus_Blocos_A_B(2)= Tensao_Fase_Media_Blocos_A_B
Alias Modbus_Blocos_A_B(3)= Tensao_Fase_A_Blocos_A_B
Alias Modbus_Blocos_A_B(4)= Tensao_Fase_B_Blocos_A_B
Alias Modbus_Blocos_A_B(5)= Tensao_Fase_C_Blocos_A_B
Alias Modbus_Blocos_A_B(6)= Corrente_Fase_Media_Blocos_A_B
Alias Modbus_Blocos_A_B(7)= Corrente_Fase_A_Blocos_A_B
Alias Modbus_Blocos_A_B(8)= Corrente_Fase_B_Blocos_A_B
Alias Modbus_Blocos_A_B(9)= Corrente_Fase_C_Blocos_A_B
Alias Modbus_Blocos_A_B(10)= Tensao_Linha_Media_Blocos_A_B
Alias Modbus_Blocos_A_B(11)= Tensao_Linha_A_Blocos_A_B
Alias Modbus_Blocos_A_B(12)= Tensao_Linha_B_Blocos_A_B
Alias Modbus_Blocos_A_B(13)= Tensao_Linha_C_Blocos_A_B
Alias Modbus_Blocos_A_B(14) = FP_Blocos_A_B
Alias Modbus_Blocos_A_B(15)= Potencia_Util_Blocos_A_B
Alias Modbus_Blocos_A_B(16)= Potencia_Reativo_Blocos_A_B
Alias Modbus_Blocos_A_B(17)= Potencia_Aparente_Blocos_A_B
Alias Modbus_Blocos_A_B(18)= Frequencia_Blocos_A_B
Alias Modbus_Blocos_A_B(19)= Corrente_Neutro_Blocos_A_B

Alias Modbus_Bloco_C(2)= Tensao_Fase_Media_Bloco_C
Alias Modbus_Bloco_C(3)= Tensao_Fase_A_Bloco_C
Alias Modbus_Bloco_C(4)= Tensao_Fase_B_Bloco_C
Alias Modbus_Bloco_C(5)= Tensao_Fase_C_Bloco_C
Alias Modbus_Bloco_C(6)= Corrente_Fase_Media_Bloco_C
Alias Modbus_Bloco_C(7)= Corrente_Fase_A_Bloco_C
Alias Modbus_Bloco_C(8)= Corrente_Fase_B_Bloco_C
Alias Modbus_Bloco_C(9)= Corrente_Fase_C_Bloco_C
Alias Modbus_Bloco_C(10)= Tensao_Linha_Media_Bloco_C
Alias Modbus_Bloco_C(11)= Tensao_Linha_A_Bloco_C
Alias Modbus_Bloco_C(12)= Tensao_Linha_B_Bloco_C
Alias Modbus_Bloco_C(13)= Tensao_Linha_C_Bloco_C
Alias Modbus_Bloco_C(14) = FP_Bloco_C
Alias Modbus_Bloco_C(15)= Potencia_Util_Bloco_C
Alias Modbus_Bloco_C(16)= Potencia_Reativo_Bloco_C
Alias Modbus_Bloco_C(17)= Potencia_Aparente_Bloco_C
Alias Modbus_Bloco_C(18)= Frequencia_Bloco_C
Alias Modbus_Bloco_C(19)= Corrente_Neutro_Bloco_C

Alias Modbus_Carr_eBus(2)= Tensao_Fase_Media_Carr_eBus
Alias Modbus_Carr_eBus(3)= Tensao_Fase_A_Carr_eBus
Alias Modbus_Carr_eBus(4)= Tensao_Fase_B_Carr_eBus
Alias Modbus_Carr_eBus(5)= Tensao_Fase_C_Carr_eBus
Alias Modbus_Carr_eBus(6)= Corrente_Fase_Media_Carr_eBus
Alias Modbus_Carr_eBus(7)= Corrente_Fase_A_Carr_eBus
Alias Modbus_Carr_eBus(8)= Corrente_Fase_B_Carr_eBus
Alias Modbus_Carr_eBus(9)= Corrente_Fase_C_Carr_eBus
Alias Modbus_Carr_eBus(10)= Tensao_Linha_Media_Carr_eBus
Alias Modbus_Carr_eBus(11)= Tensao_Linha_A_Carr_eBus
Alias Modbus_Carr_eBus(12)= Tensao_Linha_B_Carr_eBus
Alias Modbus_Carr_eBus(13)= Tensao_Linha_C_Carr_eBus
Alias Modbus_Carr_eBus(14) = FP_Carr_eBus
Alias Modbus_Carr_eBus(15)= Potencia_Util_Carr_eBus
Alias Modbus_Carr_eBus(16)= Potencia_Reativo_Carr_eBus
Alias Modbus_Carr_eBus(17)= Potencia_Aparente_Carr_eBus
Alias Modbus_Carr_eBus(18)= Frequencia_Carr_eBus
Alias Modbus_Carr_eBus(19)= Corrente_Neutro_Carr_eBus

Alias Modbus_FV_Blocos_A_B(2)= Tensao_Fase_Media_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(3)= Tensao_Fase_A_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(4)= Tensao_Fase_B_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(5)= Tensao_Fase_C_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(6)= Corrente_Fase_Media_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(7)= Corrente_Fase_A_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(8)= Corrente_Fase_B_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(9)= Corrente_Fase_C_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(10)= Tensao_Linha_Media_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(11)= Tensao_Linha_A_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(12)= Tensao_Linha_B_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(13)= Tensao_Linha_C_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(14) = FP_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(15)= Potencia_Util_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(16)= Potencia_Reativo_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(17)= Potencia_Aparente_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(18)= Frequencia_FV_Blocos_A_B
Alias Modbus_FV_Blocos_A_B(19)= Corrente_Neutro_FV_Blocos_A_B

Alias Modbus_PCS(2)= Tensao_Fase_Media_PCS
Alias Modbus_PCS(3)= Tensao_Fase_A_PCS
Alias Modbus_PCS(4)= Tensao_Fase_B_PCS
Alias Modbus_PCS(5)= Tensao_Fase_C_PCS
Alias Modbus_PCS(6)= Corrente_Fase_Media_PCS
Alias Modbus_PCS(7)= Corrente_Fase_A_PCS
Alias Modbus_PCS(8)= Corrente_Fase_B_PCS
Alias Modbus_PCS(9)= Corrente_Fase_C_PCS
Alias Modbus_PCS(10)= Tensao_Linha_Media_PCS
Alias Modbus_PCS(11)= Tensao_Linha_A_PCS
Alias Modbus_PCS(12)= Tensao_Linha_B_PCS
Alias Modbus_PCS(13)= Tensao_Linha_C_PCS
Alias Modbus_PCS(14) = FP_PCS
Alias Modbus_PCS(15)= Potencia_Util_PCS
Alias Modbus_PCS(16)= Potencia_Reativo_PCS
Alias Modbus_PCS(17)= Potencia_Aparente_PCS
Alias Modbus_PCS(18)= Frequencia_PCS
Alias Modbus_PCS(19)= Corrente_Neutro_PCS


Alias Modbus_PCS_real(2) = MRR_PCS_TENSAO_FASE_R
Alias Modbus_PCS_real(3) = MRR_PCS_CORRENTE_FASE_R
Alias Modbus_PCS_real(4) = MRR_PCS_TENSAO_INV_FASE_R
Alias Modbus_PCS_real(5) = MRR_PCS_CORRENTE_INV_FASE_R
Alias Modbus_PCS_real(6) = MRR_PCS_TENSAO_LINHA_R_S
Alias Modbus_PCS_real(7) = MRR_PCS_POTENCIA_FASE_R 
Alias Modbus_PCS_real(8) = MRR_PCS_COS_FI_FASE_R
Alias Modbus_PCS_real(9) = MRR_PCS_CARGA_FASE_R_PCENTO
Alias Modbus_PCS_real(10) = MRR_PCS_TEMP_FASE_R_C 
Alias Modbus_PCS_real(11) = MRR_PCS_TEMP_FASE_R_F
Alias Modbus_PCS_real(12) = MRR_PCS_TENSAO_FASE_S
Alias Modbus_PCS_real(13) = MRR_PCS_CORRENTE_FASE_S
Alias Modbus_PCS_real(14) = MRR_PCS_TENSAO_INV_FASE_S
Alias Modbus_PCS_real(15) = MRR_PCS_CORRENTE_INV_FASE_S
Alias Modbus_PCS_real(16) = MRR_PCS_TENSAO_LINHA_S_T
Alias Modbus_PCS_real(17) = MRR_PCS_POTENCIA_FASE_S 
Alias Modbus_PCS_real(18) = MRR_PCS_COS_FI_FASE_S
Alias Modbus_PCS_real(19) = MRR_PCS_CARGA_FASE_S_PCENTO
Alias Modbus_PCS_real(20) = MRR_PCS_TEMP_FASE_S_C 
Alias Modbus_PCS_real(21) = MRR_PCS_TEMP_FASE_S_F
Alias Modbus_PCS_real(22) = MRR_PCS_TENSAO_FASE_T
Alias Modbus_PCS_real(23) = MRR_PCS_CORRENTE_FASE_T
Alias Modbus_PCS_real(24) = MRR_PCS_TENSAO_INV_FASE_T
Alias Modbus_PCS_real(25) = MRR_PCS_CORRENTE_INV_FASE_T
Alias Modbus_PCS_real(26) = MRR_PCS_TENSAO_LINHA_T_R
Alias Modbus_PCS_real(27) = MRR_PCS_POTENCIA_FASE_T 
Alias Modbus_PCS_real(28) = MRR_PCS_COS_FI_FASE_T
Alias Modbus_PCS_real(29) = MRR_PCS_CARGA_FASE_T_PCENTO
Alias Modbus_PCS_real(30) = MRR_PCS_TEMP_FASE_T_C 
Alias Modbus_PCS_real(31) = MRR_PCS_TEMP_FASE_T_F
Alias Modbus_PCS_real(32) = MRR_PCS_TENSAO_BATERIA_TOTAL
Alias Modbus_PCS_real(33) = MRR_PCS_TENSAO_BATERIA_BAR_POS
Alias Modbus_PCS_real(34) = MRR_PCS_TENSAO_BATERIA_BAR_NEG
Alias Modbus_PCS_real(35) = MRR_PCS_CORRENTE_BATERIA_BAR_POS
Alias Modbus_PCS_real(36) = MRR_PCS_CORRENTE_BATERIA_BAR_NEG
Alias Modbus_PCS_real(37) = MRR_PCS_TENSAO_BAR_CC_TOTAL
Alias Modbus_PCS_real(38) = MRR_PCS_TENSAO_BAR_CC_POS
Alias Modbus_PCS_real(39) = MRR_PCS_TENSAO_BAR_CC_NEG
Alias Modbus_PCS_real(40) = MRR_PCS_COMANDO_ANALOG
Alias Modbus_PCS_real(41) = MRR_PCS_NIVEL_POT_REQUIS_PCENTO
Alias Modbus_PCS_real(42) = MRR_PCS_CARGA_ATUAL
Alias Modbus_PCS_real(43) = MRR_PCS_CARGA_ATUAL_PCENTO
Alias Modbus_PCS_real(44) = MRR_PCS_FREQUENCIA_CA
Alias Modbus_PCS_real(45) = MRR_PCS_TEMP_GABINETE_C
Alias Modbus_PCS_real(46) = MRR_PCS_TEMP_GABINETE_F
Alias Modbus_PCS_real(47) = MRR_PCS_TENSAO_FONTE_INTERNA
Alias Modbus_PCS_real(48) = MRR_PCS_NIVEL_BATERIA_PCENTO
Alias Modbus_PCS_real(49) = MRR_PCS_FATOR_POTENCIA
Alias Modbus_PCS_real(50) = MRR_PCS_FATOR_POTENCIA_PREC
Alias Modbus_PCS_real(51) = MRR_PCS_P_REF_AMOSTRADO
Alias Modbus_PCS_real(52) = MRR_PCS_Q_REF_AMOSTRADO


Alias Modbus_FV_BLOC_C(2) = MRR_MM_FV_BLOC_C_VFASE_MEDIA '14188 ate 14222
Alias Modbus_FV_BLOC_C(3) = MRR_MM_FV_BLOC_C_VFASE_A
Alias Modbus_FV_BLOC_C(4) = MRR_MM_FV_BLOC_C_VFASE_B
Alias Modbus_FV_BLOC_C(5) = MRR_MM_FV_BLOC_C_VFASE_C
Alias Modbus_FV_BLOC_C(6) = MRR_MM_FV_BLOC_C_IFASE_MEDIA
Alias Modbus_FV_BLOC_C(7) = MRR_MM_FV_BLOC_C_IFASE_A
Alias Modbus_FV_BLOC_C(8) = MRR_MM_FV_BLOC_C_IFASE_B 
Alias Modbus_FV_BLOC_C(9) = MRR_MM_FV_BLOC_C_IFASE_C
Alias Modbus_FV_BLOC_C(10) = MRR_MM_FV_BLOC_C_VLINHA_MEDIA
Alias Modbus_FV_BLOC_C(11) = MRR_MM_FV_BLOC_C_VLINHA_AB 
Alias Modbus_FV_BLOC_C(12) = MRR_MM_FV_BLOC_C_VLINHA_BC
Alias Modbus_FV_BLOC_C(13) = MRR_MM_FV_BLOC_C_VLINHA_CA
Alias Modbus_FV_BLOC_C(14) = MRR_MM_FV_BLOC_C_FP
Alias Modbus_FV_BLOC_C(15) = MRR_MM_FV_BLOC_C_P_TOTAL
Alias Modbus_FV_BLOC_C(16) = MRR_MM_FV_BLOC_C_Q_TOTAL
Alias Modbus_FV_BLOC_C(17) = MRR_MM_FV_BLOC_C_S_TOTAL
Alias Modbus_FV_BLOC_C(18) = MRR_MM_FV_BLOC_C_FREQ
Alias Modbus_FV_BLOC_C(19) = MRR_MM_FV_BLOC_C_I_NEUTRO 

Alias Modbus_BAT_2_VIDA(2) = MRR_MM_RES_BAT2V_VFASE_MEDIA
Alias Modbus_BAT_2_VIDA(3) = MRR_MM_RES_BAT2V_VFASE_A
Alias Modbus_BAT_2_VIDA(4) = MRR_MM_RES_BAT2V_VFASE_B
Alias Modbus_BAT_2_VIDA(5) = MRR_MM_RES_BAT2V_VFASE_C
Alias Modbus_BAT_2_VIDA(6) = MRR_MM_RES_BAT2V_IFASE_MEDIA
Alias Modbus_BAT_2_VIDA(7) = MRR_MM_RES_BAT2V_IFASE_A
Alias Modbus_BAT_2_VIDA(8) = MRR_MM_RES_BAT2V_IFASE_B 
Alias Modbus_BAT_2_VIDA(9) = MRR_MM_RES_BAT2V_IFASE_C
Alias Modbus_BAT_2_VIDA(10) = MRR_MM_RES_BAT2V_VLINHA_MEDIA
Alias Modbus_BAT_2_VIDA(11) = MRR_MM_RES_BAT2V_VLINHA_AB 
Alias Modbus_BAT_2_VIDA(12) = MRR_MM_RES_BAT2V_VLINHA_BC
Alias Modbus_BAT_2_VIDA(13) = MRR_MM_RES_BAT2V_VLINHA_CA
Alias Modbus_BAT_2_VIDA(14) = MRR_MM_RES_BAT2V_FP
Alias Modbus_BAT_2_VIDA(15) = MRR_MM_RES_BAT2V_P_TOTAL
Alias Modbus_BAT_2_VIDA(16) = MRR_MM_RES_BAT2V_Q_TOTAL
Alias Modbus_BAT_2_VIDA(17) = MRR_MM_RES_BAT2V_S_TOTAL
Alias Modbus_BAT_2_VIDA(18) = MRR_MM_RES_BAT2V_FREQ
Alias Modbus_BAT_2_VIDA(19) = MRR_MM_RES_BAT2V_I_NEUTRO 

Alias Modbus_RESERVA(2) = MRR_MM_RESERVA_VFASE_MEDIA '14188 ate 14222
Alias Modbus_RESERVA(3) = MRR_MM_RESERVA_VFASE_A
Alias Modbus_RESERVA(4) = MRR_MM_RESERVA_VFASE_B
Alias Modbus_RESERVA(5) = MRR_MM_RESERVA_VFASE_C
Alias Modbus_RESERVA(6) = MRR_MM_RESERVA_IFASE_MEDIA
Alias Modbus_RESERVA(7) = MRR_MM_RESERVA_IFASE_A
Alias Modbus_RESERVA(8) = MRR_MM_RESERVA_IFASE_B 
Alias Modbus_RESERVA(9) = MRR_MM_RESERVA_IFASE_C
Alias Modbus_RESERVA(10) = MRR_MM_RESERVA_VLINHA_MEDIA
Alias Modbus_RESERVA(11) = MRR_MM_RESERVA_VLINHA_AB 
Alias Modbus_RESERVA(12) = MRR_MM_RESERVA_VLINHA_BC
Alias Modbus_RESERVA(13) = MRR_MM_RESERVA_VLINHA_CA
Alias Modbus_RESERVA(14) = MRR_MM_RESERVA_FP
Alias Modbus_RESERVA(15) = MRR_MM_RESERVA_P_TOTAL
Alias Modbus_RESERVA(16) = MRR_MM_RESERVA_Q_TOTAL
Alias Modbus_RESERVA(17) = MRR_MM_RESERVA_S_TOTAL
Alias Modbus_RESERVA(18) = MRR_MM_RESERVA_FREQ
Alias Modbus_RESERVA(19) = MRR_MM_RESERVA_I_NEUTRO 

'Declare Other Variables
'Example:
'Dim Counter

'Define Data Tables.
DataTable (GARANTIA,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Saida_BMS,FP2,0)
FieldNames ("System_Voltage_Average")
Maximum (1,Tensao_Saida_BMS,FP2, 0,0)
FieldNames ("System_Voltage_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("System_Voltage_Min")
Average (1,Corrente_Saida_BMS,FP2,0)
FieldNames ("System_Current_Average")
Maximum (1,Corrente_Saida_BMS,FP2,0,0)
FieldNames ("System_Current_Max")
Minimum (1,Corrente_Saida_BMS,FP2,0,0)
FieldNames ("System_Current_Min")
Average (1,SOC_BMS,FP2,0)
FieldNames ("System_SOC_Average")
Maximum (1,SOC_BMS,FP2,0,0)
FieldNames ("System_SOC_Max")
Minimum (1,SOC_BMS,FP2,0,0)
FieldNames ("System_SOC_Min")
Average (1,Temp_Max_Cels_BMS,FP2,0)
FieldNames ("Max_Cell_Temp_of_system_Average")
Maximum (1,Temp_Max_Cels_BMS,FP2,0,0)
FieldNames ("Max_Cell_Temp_of_system_Max")
Minimum (1,Temp_Max_Cels_BMS,FP2,0,0)
FieldNames ("Max_Cell_Temp_of_system_Min")
Average (1,Temp_Min_Cels_BMS,FP2,0)
FieldNames ("Min_Cell_Temp_of_system_Average")
Maximum (1,Temp_Min_Cels_BMS,FP2,0,0)
FieldNames ("Min_Cell_Temp_of_system_Max")
Minimum (1,Temp_Min_Cels_BMS,FP2,0,0)
FieldNames ("Min_Cell_Temp_of_system_Min")
Average (1,Tensao_Max_Cels_BMS,FP2,0)
FieldNames ("Cell_voltage_max_Average")
Maximum (1,Tensao_Max_Cels_BMS,FP2,0,0)
FieldNames ("Cell_voltage_max_Max")
Minimum (1,Tensao_Max_Cels_BMS,FP2,0,0)
FieldNames ("Cell_voltage_max_Min")
Average (1,Tensao_Min_Cels_BMS,FP2,0)
FieldNames ("Cell_voltage_min_Average")
Maximum (1,Tensao_Min_Cels_BMS,FP2,0,0)
FieldNames ("Cell_voltage_min_Max")
Minimum (1,Tensao_Min_Cels_BMS,FP2,0,0)
FieldNames ("Cell_voltage_min_Min")
Average (1,Temp_Container,FP2,0)
FieldNames ("Temp_Container_Average")
Maximum (1,Temp_Container,FP2,0,0)
FieldNames ("Temp_Container_Max")
Minimum (1,Temp_Container,FP2,0,0)
FieldNames ("Temp_Container_Min")
Average (1,Umidade_Relativa_Container,FP2,0)
FieldNames ("Umidade_Container_Average")
Maximum (1,Umidade_Relativa_Container,FP2,0,0)
FieldNames ("Umidade_Container_Max")
Minimum (1,Umidade_Relativa_Container,FP2,0,0)
FieldNames ("Umidade_Container_Min")
EndTable


DataTable (QDCA,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Fase_Media_QDCA,FP2,0)
FieldNames ("Tensao_Fase_Media_QDCA_Average")
Maximum (1,Tensao_Fase_Media_QDCA,FP2, 0,0)
FieldNames ("Tensao_Fase_Media_QDCA_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("Tensao_Fase_Media_QDCA_Min")
Average (1,Tensao_Fase_A_QDCA,FP2,0)
FieldNames ("Tensao_Fase_A_QDCA_Average")
Maximum (1,Tensao_Fase_A_QDCA,FP2,0,0)
FieldNames ("Tensao_Fase_A_QDCA_Max")
Minimum (1,Tensao_Fase_A_QDCA,FP2,0,0)
FieldNames ("Tensao_Fase_A_QDCA_Min")
Average (1,Tensao_Fase_B_QDCA,FP2,0)
FieldNames ("Tensao_Fase_B_QDCA_Average")
Maximum (1,Tensao_Fase_B_QDCA,FP2,0,0)
FieldNames ("Tensao_Fase_B_QDCA_Max")
Minimum (1,Tensao_Fase_B_QDCA,FP2,0,0)
FieldNames ("Tensao_Fase_B_QDCA_Min")
Average (1,Tensao_Fase_C_QDCA,FP2,0)
FieldNames ("Tensao_Fase_C_QDCA_Average")
Maximum (1,Tensao_Fase_C_QDCA,FP2,0,0)
FieldNames ("Tensao_Fase_C_QDCA_Max")
Minimum (1,Tensao_Fase_C_QDCA,FP2,0,0)
FieldNames ("Tensao_Fase_C_QDCA_Min")
Average (1,Corrente_Fase_Media_QDCA,FP2,0)
FieldNames ("Corrente_Fase_Media_QDCA_Average")
Maximum (1,Corrente_Fase_Media_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_Media_QDCA_Max")
Minimum (1,Corrente_Fase_Media_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_Media_QDCA_Min")
Average (1,Corrente_Fase_A_QDCA,FP2,0)
FieldNames ("Corrente_Fase_A_QDCA_Average")
Maximum (1,Corrente_Fase_A_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_A_QDCA_Max")
Minimum (1,Corrente_Fase_A_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_A_QDCA_Min")

Average (1,Corrente_Fase_B_QDCA,FP2,0)
FieldNames ("Corrente_Fase_B_QDCA_Average")
Maximum (1,Corrente_Fase_B_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_B_QDCA_Max")
Minimum (1,Corrente_Fase_B_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_B_QDCA_Min")

Average (1,Corrente_Fase_C_QDCA,FP2,0)
FieldNames ("Corrente_Fase_C_QDCA_Average")
Maximum (1,Corrente_Fase_C_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_C_QDCA_Max")
Minimum (1,Corrente_Fase_C_QDCA,FP2,0,0)
FieldNames ("Corrente_Fase_C_QDCA_Min")

Average (1,Tensao_Linha_Media_QDCA,FP2,0)
FieldNames ("Tensao_Linha_Media_QDCA_Average")
Maximum (1,Tensao_Linha_Media_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_Media_QDCA_Max")
Minimum (1,Tensao_Linha_Media_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_Media_QDCA_Min")

Average (1,Tensao_Linha_A_QDCA,FP2,0)
FieldNames ("Tensao_Linha_A_QDCA_Average")
Maximum (1,Tensao_Linha_A_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_A_QDCA_Max")
Minimum (1,Tensao_Linha_A_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_A_QDCA_Min")

Average (1,Tensao_Linha_B_QDCA,FP2,0)
FieldNames ("Tensao_Linha_B_QDCA_Average")
Maximum (1,Tensao_Linha_B_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_B_QDCA_Max")
Minimum (1,Tensao_Linha_B_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_B_QDCA_Min")

Average (1,Tensao_Linha_C_QDCA,FP2,0)
FieldNames ("Tensao_Linha_C_QDCA_Average")
Maximum (1,Tensao_Linha_C_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_C_QDCA_Max")
Minimum (1,Tensao_Linha_C_QDCA,FP2,0,0)
FieldNames ("Tensao_Linha_C_QDCA_Min")

Average (1,FP_QDCA,FP2,0)
FieldNames ("FP_QDCA_Average")
Maximum (1,FP_QDCA,FP2,0,0)
FieldNames ("FP_QDCA_Max")
Minimum (1,FP_QDCA,FP2,0,0)
FieldNames ("FP_QDCA_Min")

Average (1,Potencia_Util_QDCA,FP2,0)
FieldNames ("Potencia_Util_QDCA_Average")
Maximum (1,Potencia_Util_QDCA,FP2,0,0)
FieldNames ("Potencia_Util_QDCA_Max")
Minimum (1,Potencia_Util_QDCA,FP2,0,0)
FieldNames ("Potencia_Util_QDCA_Min")

Average (1,Potencia_Reativo_QDCA,FP2,0)
FieldNames ("Potencia_Reativo_QDCA_Average")
Maximum (1,Potencia_Reativo_QDCA,FP2,0,0)
FieldNames ("Potencia_Reativo_QDCA_Max")
Minimum (1,Potencia_Reativo_QDCA,FP2,0,0)
FieldNames ("Potencia_Reativo_QDCA_Min")

Average (1,Potencia_Aparente_QDCA,FP2,0)
FieldNames ("Potencia_Aparente_QDCA_Average")
Maximum (1,Potencia_Aparente_QDCA,FP2,0,0)
FieldNames ("Potencia_Aparente_QDCA_Max")
Minimum (1,Potencia_Aparente_QDCA,FP2,0,0)
FieldNames ("Potencia_Aparente_QDCA_Min")

Average (1,Frequencia_QDCA,FP2,0)
FieldNames ("Frequencia_QDCA_Average")
Maximum (1,Frequencia_QDCA,FP2,0,0)
FieldNames ("Frequencia_QDCA_Max")
Minimum (1,Frequencia_QDCA,FP2,0,0)
FieldNames ("Frequencia_QDCA_Min")

Average (1,Corrente_Neutro_QDCA,FP2,0)
FieldNames ("Corrente_Neutro_QDCA_Average")
Maximum (1,Corrente_Neutro_QDCA,FP2,0,0)
FieldNames ("Corrente_Neutro_QDCA_Max")
Minimum (1,Corrente_Neutro_QDCA,FP2,0,0)
FieldNames ("Corrente_Neutro_QDCA_Min")
EndTable


DataTable (Blocos_A_B,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Fase_Media_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_Media_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_Media_Blocos_A_B,FP2, 0,0)
FieldNames ("Tensao_Fase_Media_Blocos_A_B_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("Tensao_Fase_Media_Blocos_A_B_Min")
Average (1,Tensao_Fase_A_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_A_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_A_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_A_Blocos_A_B_Max")
Minimum (1,Tensao_Fase_A_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_A_Blocos_A_B_Min")
Average (1,Tensao_Fase_B_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_B_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_B_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_B_Blocos_A_B_Max")
Minimum (1,Tensao_Fase_B_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_B_Blocos_A_B_Min")
Average (1,Tensao_Fase_C_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_C_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_C_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_C_Blocos_A_B_Max")
Minimum (1,Tensao_Fase_C_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_C_Blocos_A_B_Min")
Average (1,Corrente_Fase_Media_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_Media_Blocos_A_B_Average")
Maximum (1,Corrente_Fase_Media_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_Media_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_Media_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_Media_Blocos_A_B_Min")
Average (1,Corrente_Fase_A_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_A_Blocos_A_B_Average")
Maximum (1,Corrente_Fase_A_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_A_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_A_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_A_Blocos_A_B_Min")

Average (1,Corrente_Fase_B_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_B_Blocos_A_B_Average")
Maximum (1,Corrente_Fase_B_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_B_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_B_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_B_Blocos_A_B_Min")

Average (1,Corrente_Fase_C_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_C_Blocos_A_B_Average")
Maximum (1,Corrente_Fase_C_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_C_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_C_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_C_Blocos_A_B_Min")

Average (1,Tensao_Linha_Media_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_Media_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_Media_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_Media_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_Media_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_Media_Blocos_A_B_Min")

Average (1,Tensao_Linha_A_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_A_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_A_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_A_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_A_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_A_Blocos_A_B_Min")

Average (1,Tensao_Linha_B_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_B_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_B_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_B_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_B_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_B_Blocos_A_B_Min")

Average (1,Tensao_Linha_C_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_C_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_C_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_C_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_C_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_C_Blocos_A_B_Min")

Average (1,FP_Blocos_A_B,FP2,0)
FieldNames ("FP_Blocos_A_B_Average")
Maximum (1,FP_Blocos_A_B,FP2,0,0)
FieldNames ("FP_Blocos_A_B_Max")
Minimum (1,FP_Blocos_A_B,FP2,0,0)
FieldNames ("FP_Blocos_A_B_Min")

Average (1,Potencia_Util_Blocos_A_B,FP2,0)
FieldNames ("Potencia_Util_Blocos_A_B_Average")
Maximum (1,Potencia_Util_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Util_Blocos_A_B_Max")
Minimum (1,Potencia_Util_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Util_Blocos_A_B_Min")

Average (1,Potencia_Reativo_Blocos_A_B,FP2,0)
FieldNames ("Potencia_Reativo_Blocos_A_B_Average")
Maximum (1,Potencia_Reativo_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Reativo_Blocos_A_B_Max")
Minimum (1,Potencia_Reativo_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Reativo_Blocos_A_B_Min")

Average (1,Potencia_Aparente_Blocos_A_B,FP2,0)
FieldNames ("Potencia_Aparente_Blocos_A_B_Average")
Maximum (1,Potencia_Aparente_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Aparente_Blocos_A_B_Max")
Minimum (1,Potencia_Aparente_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Aparente_Blocos_A_B_Min")

Average (1,Frequencia_Blocos_A_B,FP2,0)
FieldNames ("Frequencia_Blocos_A_B_Average")
Maximum (1,Frequencia_Blocos_A_B,FP2,0,0)
FieldNames ("Frequencia_Blocos_A_B_Max")
Minimum (1,Frequencia_Blocos_A_B,FP2,0,0)
FieldNames ("Frequencia_Blocos_A_B_Min")

Average (1,Corrente_Neutro_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Neutro_Blocos_A_B_Average")
Maximum (1,Corrente_Neutro_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Neutro_Blocos_A_B_Max")
Minimum (1,Corrente_Neutro_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Neutro_Blocos_A_B_Min")
EndTable

DataTable (Bloco_C,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Fase_Media_Bloco_C,FP2,0)
FieldNames ("Tensao_Fase_Media_Bloco_C_Average")
Maximum (1,Tensao_Fase_Media_Bloco_C,FP2, 0,0)
FieldNames ("Tensao_Fase_Media_Bloco_C_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("Tensao_Fase_Media_Bloco_C_Min")
Average (1,Tensao_Fase_A_Bloco_C,FP2,0)
FieldNames ("Tensao_Fase_A_Bloco_C_Average")
Maximum (1,Tensao_Fase_A_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Fase_A_Bloco_C_Max")
Minimum (1,Tensao_Fase_A_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Fase_A_Bloco_C_Min")
Average (1,Tensao_Fase_B_Bloco_C,FP2,0)
FieldNames ("Tensao_Fase_B_Bloco_C_Average")
Maximum (1,Tensao_Fase_B_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Fase_B_Bloco_C_Max")
Minimum (1,Tensao_Fase_B_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Fase_B_Bloco_C_Min")
Average (1,Tensao_Fase_C_Bloco_C,FP2,0)
FieldNames ("Tensao_Fase_C_Bloco_C_Average")
Maximum (1,Tensao_Fase_C_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Fase_C_Bloco_C_Max")
Minimum (1,Tensao_Fase_C_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Fase_C_Bloco_C_Min")
Average (1,Corrente_Fase_Media_Bloco_C,FP2,0)
FieldNames ("Corrente_Fase_Media_Bloco_C_Average")
Maximum (1,Corrente_Fase_Media_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_Media_Bloco_C_Max")
Minimum (1,Corrente_Fase_Media_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_Media_Bloco_C_Min")
Average (1,Corrente_Fase_A_Bloco_C,FP2,0)
FieldNames ("Corrente_Fase_A_Bloco_C_Average")
Maximum (1,Corrente_Fase_A_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_A_Bloco_C_Max")
Minimum (1,Corrente_Fase_A_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_A_Bloco_C_Min")

Average (1,Corrente_Fase_B_Bloco_C,FP2,0)
FieldNames ("Corrente_Fase_B_Bloco_C_Average")
Maximum (1,Corrente_Fase_B_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_B_Bloco_C_Max")
Minimum (1,Corrente_Fase_B_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_B_Bloco_C_Min")

Average (1,Corrente_Fase_C_Bloco_C,FP2,0)
FieldNames ("Corrente_Fase_C_Bloco_C_Average")
Maximum (1,Corrente_Fase_C_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_C_Bloco_C_Max")
Minimum (1,Corrente_Fase_C_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Fase_C_Bloco_C_Min")

Average (1,Tensao_Linha_Media_Bloco_C,FP2,0)
FieldNames ("Tensao_Linha_Media_Bloco_C_Average")
Maximum (1,Tensao_Linha_Media_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_Media_Bloco_C_Max")
Minimum (1,Tensao_Linha_Media_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_Media_Bloco_C_Min")

Average (1,Tensao_Linha_A_Bloco_C,FP2,0)
FieldNames ("Tensao_Linha_A_Bloco_C_Average")
Maximum (1,Tensao_Linha_A_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_A_Bloco_C_Max")
Minimum (1,Tensao_Linha_A_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_A_Bloco_C_Min")

Average (1,Tensao_Linha_B_Bloco_C,FP2,0)
FieldNames ("Tensao_Linha_B_Bloco_C_Average")
Maximum (1,Tensao_Linha_B_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_B_Bloco_C_Max")
Minimum (1,Tensao_Linha_B_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_B_Bloco_C_Min")

Average (1,Tensao_Linha_C_Bloco_C,FP2,0)
FieldNames ("Tensao_Linha_C_Bloco_C_Average")
Maximum (1,Tensao_Linha_C_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_C_Bloco_C_Max")
Minimum (1,Tensao_Linha_C_Bloco_C,FP2,0,0)
FieldNames ("Tensao_Linha_C_Bloco_C_Min")


Average (1,FP_Bloco_C,FP2,0)
FieldNames ("FP_Bloco_C_Average")
Maximum (1,FP_Bloco_C,FP2,0,0)
FieldNames ("FP_Bloco_C_Max")
Minimum (1,FP_Bloco_C,FP2,0,0)
FieldNames ("FP_Bloco_C_Min")

Average (1,Potencia_Util_Bloco_C,FP2,0)
FieldNames ("Potencia_Util_Bloco_C_Average")
Maximum (1,Potencia_Util_Bloco_C,FP2,0,0)
FieldNames ("Potencia_Util_Bloco_C_Max")
Minimum (1,Potencia_Util_Bloco_C,FP2,0,0)
FieldNames ("Potencia_Util_Bloco_C_Min")

Average (1,Potencia_Reativo_Bloco_C,FP2,0)
FieldNames ("Potencia_Reativo_Bloco_C_Average")
Maximum (1,Potencia_Reativo_Bloco_C,FP2,0,0)
FieldNames ("Potencia_Reativo_Bloco_C_Max")
Minimum (1,Potencia_Reativo_Bloco_C,FP2,0,0)
FieldNames ("Potencia_Reativo_Bloco_C_Min")

Average (1,Potencia_Aparente_Bloco_C,FP2,0)
FieldNames ("Potencia_Aparente_Bloco_C_Average")
Maximum (1,Potencia_Aparente_Bloco_C,FP2,0,0)
FieldNames ("Potencia_Aparente_Bloco_C_Max")
Minimum (1,Potencia_Aparente_Bloco_C,FP2,0,0)
FieldNames ("Potencia_Aparente_Bloco_C_Min")

Average (1,Frequencia_Bloco_C,FP2,0)
FieldNames ("Frequencia_Bloco_C_Average")
Maximum (1,Frequencia_Bloco_C,FP2,0,0)
FieldNames ("Frequencia_Bloco_C_Max")
Minimum (1,Frequencia_Bloco_C,FP2,0,0)
FieldNames ("Frequencia_Bloco_C_Min")

Average (1,Corrente_Neutro_Bloco_C,FP2,0)
FieldNames ("Corrente_Neutro_Bloco_C_Average")
Maximum (1,Corrente_Neutro_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Neutro_Bloco_C_Max")
Minimum (1,Corrente_Neutro_Bloco_C,FP2,0,0)
FieldNames ("Corrente_Neutro_Bloco_C_Min")
EndTable


DataTable (Carr_eBus,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Fase_Media_Carr_eBus,FP2,0)
FieldNames ("Tensao_Fase_Media_Carr_eBus_Average")
Maximum (1,Tensao_Fase_Media_Carr_eBus,FP2, 0,0)
FieldNames ("Tensao_Fase_Media_Carr_eBus_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("Tensao_Fase_Media_Carr_eBus_Min")
Average (1,Tensao_Fase_A_Carr_eBus,FP2,0)
FieldNames ("Tensao_Fase_A_Carr_eBus_Average")
Maximum (1,Tensao_Fase_A_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Fase_A_Carr_eBus_Max")
Minimum (1,Tensao_Fase_A_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Fase_A_Carr_eBus_Min")
Average (1,Tensao_Fase_B_Carr_eBus,FP2,0)
FieldNames ("Tensao_Fase_B_Carr_eBus_Average")
Maximum (1,Tensao_Fase_B_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Fase_B_Carr_eBus_Max")
Minimum (1,Tensao_Fase_B_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Fase_B_Carr_eBus_Min")
Average (1,Tensao_Fase_C_Carr_eBus,FP2,0)
FieldNames ("Tensao_Fase_C_Carr_eBus_Average")
Maximum (1,Tensao_Fase_C_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Fase_C_Carr_eBus_Max")
Minimum (1,Tensao_Fase_C_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Fase_C_Carr_eBus_Min")
Average (1,Corrente_Fase_Media_Carr_eBus,FP2,0)
FieldNames ("Corrente_Fase_Media_Carr_eBus_Average")
Maximum (1,Corrente_Fase_Media_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_Media_Carr_eBus_Max")
Minimum (1,Corrente_Fase_Media_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_Media_Carr_eBus_Min")
Average (1,Corrente_Fase_A_Carr_eBus,FP2,0)
FieldNames ("Corrente_Fase_A_Carr_eBus_Average")
Maximum (1,Corrente_Fase_A_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_A_Carr_eBus_Max")
Minimum (1,Corrente_Fase_A_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_A_Carr_eBus_Min")

Average (1,Corrente_Fase_B_Carr_eBus,FP2,0)
FieldNames ("Corrente_Fase_B_Carr_eBus_Average")
Maximum (1,Corrente_Fase_B_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_B_Carr_eBus_Max")
Minimum (1,Corrente_Fase_B_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_B_Carr_eBus_Min")

Average (1,Corrente_Fase_C_Carr_eBus,FP2,0)
FieldNames ("Corrente_Fase_C_Carr_eBus_Average")
Maximum (1,Corrente_Fase_C_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_C_Carr_eBus_Max")
Minimum (1,Corrente_Fase_C_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Fase_C_Carr_eBus_Min")

Average (1,Tensao_Linha_Media_Carr_eBus,FP2,0)
FieldNames ("Tensao_Linha_Media_Carr_eBus_Average")
Maximum (1,Tensao_Linha_Media_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_Media_Carr_eBus_Max")
Minimum (1,Tensao_Linha_Media_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_Media_Carr_eBus_Min")

Average (1,Tensao_Linha_A_Carr_eBus,FP2,0)
FieldNames ("Tensao_Linha_A_Carr_eBus_Average")
Maximum (1,Tensao_Linha_A_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_A_Carr_eBus_Max")
Minimum (1,Tensao_Linha_A_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_A_Carr_eBus_Min")

Average (1,Tensao_Linha_B_Carr_eBus,FP2,0)
FieldNames ("Tensao_Linha_B_Carr_eBus_Average")
Maximum (1,Tensao_Linha_B_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_B_Carr_eBus_Max")
Minimum (1,Tensao_Linha_B_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_B_Carr_eBus_Min")

Average (1,Tensao_Linha_C_Carr_eBus,FP2,0)
FieldNames ("Tensao_Linha_C_Carr_eBus_Average")
Maximum (1,Tensao_Linha_C_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_C_Carr_eBus_Max")
Minimum (1,Tensao_Linha_C_Carr_eBus,FP2,0,0)
FieldNames ("Tensao_Linha_C_Carr_eBus_Min")

Average (1,FP_Carr_eBus,FP2,0)
FieldNames ("FP_Carr_eBus_Average")
Maximum (1,FP_Carr_eBus,FP2,0,0)
FieldNames ("FP_Carr_eBus_Max")
Minimum (1,FP_Carr_eBus,FP2,0,0)
FieldNames ("FP_Carr_eBus_Min")

Average (1,Potencia_Util_Carr_eBus,FP2,0)
FieldNames ("Potencia_Util_Carr_eBus_Average")
Maximum (1,Potencia_Util_Carr_eBus,FP2,0,0)
FieldNames ("Potencia_Util_Carr_eBus_Max")
Minimum (1,Potencia_Util_Carr_eBus,FP2,0,0)
FieldNames ("Potencia_Util_Carr_eBus_Min")

Average (1,Potencia_Reativo_Carr_eBus,FP2,0)
FieldNames ("Potencia_Reativo_Carr_eBus_Average")
Maximum (1,Potencia_Reativo_Carr_eBus,FP2,0,0)
FieldNames ("Potencia_Reativo_Carr_eBus_Max")
Minimum (1,Potencia_Reativo_Carr_eBus,FP2,0,0)
FieldNames ("Potencia_Reativo_Carr_eBus_Min")

Average (1,Potencia_Aparente_Carr_eBus,FP2,0)
FieldNames ("Potencia_Aparente_Carr_eBus_Average")
Maximum (1,Potencia_Aparente_Carr_eBus,FP2,0,0)
FieldNames ("Potencia_Aparente_Carr_eBus_Max")
Minimum (1,Potencia_Aparente_Carr_eBus,FP2,0,0)
FieldNames ("Potencia_Aparente_Carr_eBus_Min")

Average (1,Frequencia_Carr_eBus,FP2,0)
FieldNames ("Frequencia_Carr_eBus_Average")
Maximum (1,Frequencia_Carr_eBus,FP2,0,0)
FieldNames ("Frequencia_Carr_eBus_Max")
Minimum (1,Frequencia_Carr_eBus,FP2,0,0)
FieldNames ("Frequencia_Carr_eBus_Min")

Average (1,Corrente_Neutro_Carr_eBus,FP2,0)
FieldNames ("Corrente_Neutro_Carr_eBus_Average")
Maximum (1,Corrente_Neutro_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Neutro_Carr_eBus_Max")
Minimum (1,Corrente_Neutro_Carr_eBus,FP2,0,0)
FieldNames ("Corrente_Neutro_Carr_eBus_Min")
EndTable


DataTable (FV_Blocos_A_B,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Fase_Media_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_Media_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_Media_FV_Blocos_A_B,FP2, 0,0)
FieldNames ("Tensao_Fase_Media_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("Tensao_Fase_Media_FV_Blocos_A_B_Min")
Average (1,Tensao_Fase_A_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_A_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_A_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_A_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Fase_A_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_A_FV_Blocos_A_B_Min")
Average (1,Tensao_Fase_B_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_B_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_B_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_B_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Fase_B_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_B_FV_Blocos_A_B_Min")
Average (1,Tensao_Fase_C_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Fase_C_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Fase_C_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_C_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Fase_C_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Fase_C_FV_Blocos_A_B_Min")
Average (1,Corrente_Fase_Media_FV_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_Media_FV_Blocos_A_B_Avg")
Maximum (1,Corrente_Fase_Media_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_Media_FV_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_Media_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_Media_FV_Blocos_A_B_Min")
Average (1,Corrente_Fase_A_FV_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_A_FV_Blocos_A_B_Average")
Maximum (1,Corrente_Fase_A_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_A_FV_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_A_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_A_FV_Blocos_A_B_Min")

Average (1,Corrente_Fase_B_FV_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_B_FV_Blocos_A_B_Avg")
Maximum (1,Corrente_Fase_B_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_B_FV_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_B_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_B_FV_Blocos_A_B_Min")

Average (1,Corrente_Fase_C_FV_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Fase_C_FV_Blocos_A_B_Average")
Maximum (1,Corrente_Fase_C_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_C_FV_Blocos_A_B_Max")
Minimum (1,Corrente_Fase_C_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Fase_C_FV_Blocos_A_B_Min")

Average (1,Tensao_Linha_Media_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_Media_FV_Blocos_A_B_Avg")
Maximum (1,Tensao_Linha_Media_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_Media_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_Media_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_Media_FV_Blocos_A_B_Min")

Average (1,Tensao_Linha_A_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_A_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_A_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_A_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_A_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_A_FV_Blocos_A_B_Min")

Average (1,Tensao_Linha_B_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_B_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_B_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_B_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_B_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_B_FV_Blocos_A_B_Min")

Average (1,Tensao_Linha_C_FV_Blocos_A_B,FP2,0)
FieldNames ("Tensao_Linha_C_FV_Blocos_A_B_Average")
Maximum (1,Tensao_Linha_C_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_C_FV_Blocos_A_B_Max")
Minimum (1,Tensao_Linha_C_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Tensao_Linha_C_FV_Blocos_A_B_Min")

Average (1,FP_FV_Blocos_A_B,FP2,0)
FieldNames ("FP_FV_Blocos_A_B_Average")
Maximum (1,FP_FV_Blocos_A_B,FP2,0,0)
FieldNames ("FP_FV_Blocos_A_B_Max")
Minimum (1,FP_FV_Blocos_A_B,FP2,0,0)
FieldNames ("FP_FV_Blocos_A_B_Min")

Average (1,Potencia_Util_FV_Blocos_A_B,FP2,0)
FieldNames ("Potencia_Util_FV_Blocos_A_B_Average")
Maximum (1,Potencia_Util_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Util_FV_Blocos_A_B_Max")
Minimum (1,Potencia_Util_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Util_FV_Blocos_A_B_Min")

Average (1,Potencia_Reativo_FV_Blocos_A_B,FP2,0)
FieldNames ("Potencia_Reativo_FV_Blocos_A_B_Average")
Maximum (1,Potencia_Reativo_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Reativo_FV_Blocos_A_B_Max")
Minimum (1,Potencia_Reativo_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Reativo_FV_Blocos_A_B_Min")

Average (1,Potencia_Aparente_FV_Blocos_A_B,FP2,0)
FieldNames ("Potencia_Aparente_FV_Blocos_A_B_Average")
Maximum (1,Potencia_Aparente_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Aparente_FV_Blocos_A_B_Max")
Minimum (1,Potencia_Aparente_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Potencia_Aparente_FV_Blocos_A_B_Min")

Average (1,Frequencia_FV_Blocos_A_B,FP2,0)
FieldNames ("Frequencia_FV_Blocos_A_B_Average")
Maximum (1,Frequencia_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Frequencia_FV_Blocos_A_B_Max")
Minimum (1,Frequencia_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Frequencia_FV_Blocos_A_B_Min")

Average (1,Corrente_Neutro_FV_Blocos_A_B,FP2,0)
FieldNames ("Corrente_Neutro_FV_Blocos_A_B_Average")
Maximum (1,Corrente_Neutro_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Neutro_FV_Blocos_A_B_Max")
Minimum (1,Corrente_Neutro_FV_Blocos_A_B,FP2,0,0)
FieldNames ("Corrente_Neutro_FV_Blocos_A_B_Min")
EndTable

DataTable (PCS,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)
Average (1,Tensao_Fase_Media_PCS,FP2,0)
FieldNames ("Tensao_Fase_Media_PCS_Average")
Maximum (1,Tensao_Fase_Media_PCS,FP2, 0,0)
FieldNames ("Tensao_Fase_Media_PCS_Max")
Minimum (1,Tensao_Saida_BMS,FP2,0,0)
FieldNames ("Tensao_Fase_Media_PCS_Min")
Average (1,Tensao_Fase_A_PCS,FP2,0)
FieldNames ("Tensao_Fase_A_PCS_Average")
Maximum (1,Tensao_Fase_A_PCS,FP2,0,0)
FieldNames ("Tensao_Fase_A_PCS_Max")
Minimum (1,Tensao_Fase_A_PCS,FP2,0,0)
FieldNames ("Tensao_Fase_A_PCS_Min")
Average (1,Tensao_Fase_B_PCS,FP2,0)
FieldNames ("Tensao_Fase_B_PCS_Average")
Maximum (1,Tensao_Fase_B_PCS,FP2,0,0)
FieldNames ("Tensao_Fase_B_PCS_Max")
Minimum (1,Tensao_Fase_B_PCS,FP2,0,0)
FieldNames ("Tensao_Fase_B_PCS_Min")
Average (1,Tensao_Fase_C_PCS,FP2,0)
FieldNames ("Tensao_Fase_C_PCS_Average")
Maximum (1,Tensao_Fase_C_PCS,FP2,0,0)
FieldNames ("Tensao_Fase_C_PCS_Max")
Minimum (1,Tensao_Fase_C_PCS,FP2,0,0)
FieldNames ("Tensao_Fase_C_PCS_Min")
Average (1,Corrente_Fase_Media_PCS,FP2,0)
FieldNames ("Corrente_Fase_Media_PCS_Average")
Maximum (1,Corrente_Fase_Media_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_Media_PCS_Max")
Minimum (1,Corrente_Fase_Media_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_Media_PCS_Min")
Average (1,Corrente_Fase_A_PCS,FP2,0)
FieldNames ("Corrente_Fase_A_PCS_Average")
Maximum (1,Corrente_Fase_A_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_A_PCS_Max")
Minimum (1,Corrente_Fase_A_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_A_PCS_Min")

Average (1,Corrente_Fase_B_PCS,FP2,0)
FieldNames ("Corrente_Fase_B_PCS_Average")
Maximum (1,Corrente_Fase_B_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_B_PCS_Max")
Minimum (1,Corrente_Fase_B_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_B_PCS_Min")

Average (1,Corrente_Fase_C_PCS,FP2,0)
FieldNames ("Corrente_Fase_C_PCS_Average")
Maximum (1,Corrente_Fase_C_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_C_PCS_Max")
Minimum (1,Corrente_Fase_C_PCS,FP2,0,0)
FieldNames ("Corrente_Fase_C_PCS_Min")

Average (1,Tensao_Linha_Media_PCS,FP2,0)
FieldNames ("Tensao_Linha_Media_PCS_Average")
Maximum (1,Tensao_Linha_Media_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_Media_PCS_Max")
Minimum (1,Tensao_Linha_Media_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_Media_PCS_Min")

Average (1,Tensao_Linha_A_PCS,FP2,0)
FieldNames ("Tensao_Linha_A_PCS_Average")
Maximum (1,Tensao_Linha_A_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_A_PCS_Max")
Minimum (1,Tensao_Linha_A_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_A_PCS_Min")

Average (1,Tensao_Linha_B_PCS,FP2,0)
FieldNames ("Tensao_Linha_B_PCS_Average")
Maximum (1,Tensao_Linha_B_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_B_PCS_Max")
Minimum (1,Tensao_Linha_B_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_B_PCS_Min")

Average (1,Tensao_Linha_C_PCS,FP2,0)
FieldNames ("Tensao_Linha_C_PCS_Average")
Maximum (1,Tensao_Linha_C_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_C_PCS_Max")
Minimum (1,Tensao_Linha_C_PCS,FP2,0,0)
FieldNames ("Tensao_Linha_C_PCS_Min")

Average (1,FP_PCS,FP2,0)
FieldNames ("FP_PCS_Average")
Maximum (1,FP_PCS,FP2,0,0)
FieldNames ("FP_PCS_Max")
Minimum (1,FP_PCS,FP2,0,0)
FieldNames ("FP_PCS_Min")

Average (1,Potencia_Util_PCS,FP2,0)
FieldNames ("Potencia_Util_PCS_Average")
Maximum (1,Potencia_Util_PCS,FP2,0,0)
FieldNames ("Potencia_Util_PCS_Max")
Minimum (1,Potencia_Util_PCS,FP2,0,0)
FieldNames ("Potencia_Util_PCS_Min")

Average (1,Potencia_Reativo_PCS,FP2,0)
FieldNames ("Potencia_Reativo_PCS_Average")
Maximum (1,Potencia_Reativo_PCS,FP2,0,0)
FieldNames ("Potencia_Reativo_PCS_Max")
Minimum (1,Potencia_Reativo_PCS,FP2,0,0)
FieldNames ("Potencia_Reativo_PCS_Min")

Average (1,Potencia_Aparente_PCS,FP2,0)
FieldNames ("Potencia_Aparente_PCS_Average")
Maximum (1,Potencia_Aparente_PCS,FP2,0,0)
FieldNames ("Potencia_Aparente_PCS_Max")
Minimum (1,Potencia_Aparente_PCS,FP2,0,0)
FieldNames ("Potencia_Aparente_PCS_Min")

Average (1,Frequencia_PCS,FP2,0)
FieldNames ("Frequencia_PCS_Average")
Maximum (1,Frequencia_PCS,FP2,0,0)
FieldNames ("Frequencia_PCS_Max")
Minimum (1,Frequencia_PCS,FP2,0,0)
FieldNames ("Frequencia_PCS_Min")

Average (1,Corrente_Neutro_PCS,FP2,0)
FieldNames ("Corrente_Neutro_PCS_Average")
Maximum (1,Corrente_Neutro_PCS,FP2,0,0)
FieldNames ("Corrente_Neutro_PCS_Max")
Minimum (1,Corrente_Neutro_PCS,FP2,0,0)
FieldNames ("Corrente_Neutro_PCS_Min")
EndTable



DataTable (PCS_real,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)

Average (1,MRR_PCS_TENSAO_FASE_R,FP2,0)
FieldNames ("MRR_PCS_TENSAO_FASE_R_Average")
Maximum (1,MRR_PCS_TENSAO_FASE_R,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_FASE_R_Max")
Minimum (1,MRR_PCS_TENSAO_FASE_R,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_FASE_R_Min")

Average (1,MRR_PCS_CORRENTE_FASE_R,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_R_Average")
Maximum (1,MRR_PCS_CORRENTE_FASE_R,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_R_Max")
Minimum (1,MRR_PCS_CORRENTE_FASE_R,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_R_Min")

Average (1,MRR_PCS_TENSAO_INV_FASE_R,FP2,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_R_Average")
Maximum (1,MRR_PCS_TENSAO_INV_FASE_R,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_R_Max")
Minimum (1,MRR_PCS_TENSAO_INV_FASE_R,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_R_Min")

Average (1,MRR_PCS_CORRENTE_INV_FASE_R,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_R_Average")
Maximum (1,MRR_PCS_CORRENTE_INV_FASE_R,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_R_Max")
Minimum (1,MRR_PCS_CORRENTE_INV_FASE_R,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_R_Min")

Average (1,MRR_PCS_TENSAO_LINHA_R_S,FP2,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_R_S_Average")
Maximum (1,MRR_PCS_TENSAO_LINHA_R_S,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_R_S_Max")
Minimum (1,MRR_PCS_TENSAO_LINHA_R_S,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_R_S_Min")

Average (1,MRR_PCS_POTENCIA_FASE_R ,FP2,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_R_Average")
Maximum (1,MRR_PCS_POTENCIA_FASE_R ,FP2, 0,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_R_Max")
Minimum (1,MRR_PCS_POTENCIA_FASE_R ,FP2,0,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_R_Min")

Average (1,MRR_PCS_COS_FI_FASE_R,FP2,0)
FieldNames ("MRR_PCS_COS_FI_FASE_R_Average")
Maximum (1,MRR_PCS_COS_FI_FASE_R,FP2, 0,0)
FieldNames ("MRR_PCS_COS_FI_FASE_R_Max")
Minimum (1,MRR_PCS_COS_FI_FASE_R,FP2,0,0)
FieldNames ("MRR_PCS_COS_FI_FASE_R_Min")

Average (1,MRR_PCS_CARGA_FASE_R_PCENTO,FP2,0)
FieldNames ("MRR_PCS_CARGA_FASE_R_PCENTO_Average")
Maximum (1,MRR_PCS_CARGA_FASE_R_PCENTO,FP2, 0,0)
FieldNames ("MRR_PCS_CARGA_FASE_R_PCENTO_Max")
Minimum (1,MRR_PCS_CARGA_FASE_R_PCENTO,FP2,0,0)
FieldNames ("MRR_PCS_CARGA_FASE_R_PCENTO_Min")

Average (1,MRR_PCS_TEMP_FASE_R_C ,FP2,0)
FieldNames ("MRR_PCS_TEMP_FASE_R_C_Average")
Maximum (1,MRR_PCS_TEMP_FASE_R_C ,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_FASE_R_C_Max")
Minimum (1,MRR_PCS_TEMP_FASE_R_C ,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_FASE_R_C_Min")

Average (1,MRR_PCS_TEMP_FASE_R_F,FP2,0)
FieldNames ("MRR_PCS_TEMP_FASE_R_F_Average")
Maximum (1,MRR_PCS_TEMP_FASE_R_F,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_FASE_R_F_Max")
Minimum (1,MRR_PCS_TEMP_FASE_R_F,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_FASE_R_F_Min")

Average (1,MRR_PCS_TENSAO_FASE_S,FP2,0)
FieldNames ("MRR_PCS_TENSAO_FASE_S_Average")
Maximum (1,MRR_PCS_TENSAO_FASE_S,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_FASE_S_Max")
Minimum (1,MRR_PCS_TENSAO_FASE_S,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_FASE_S_Min")

Average (1,MRR_PCS_CORRENTE_FASE_S,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_S_Average")
Maximum (1,MRR_PCS_CORRENTE_FASE_S,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_S_Max")
Minimum (1,MRR_PCS_CORRENTE_FASE_S,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_S_Min")

Average (1,MRR_PCS_TENSAO_INV_FASE_S,FP2,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_S_Average")
Maximum (1,MRR_PCS_TENSAO_INV_FASE_S,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_S_Max")
Minimum (1,MRR_PCS_TENSAO_INV_FASE_S,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_S_Min")

Average (1,MRR_PCS_CORRENTE_INV_FASE_S,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_S_Average")
Maximum (1,MRR_PCS_CORRENTE_INV_FASE_S,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_S_Max")
Minimum (1,MRR_PCS_CORRENTE_INV_FASE_S,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_S_Min")

Average (1,MRR_PCS_TENSAO_LINHA_S_T,FP2,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_S_T_Average")
Maximum (1,MRR_PCS_TENSAO_LINHA_S_T,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_S_T_Max")
Minimum (1,MRR_PCS_TENSAO_LINHA_S_T,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_S_T_Min")

Average (1,MRR_PCS_POTENCIA_FASE_S ,FP2,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_S_Average")
Maximum (1,MRR_PCS_POTENCIA_FASE_S ,FP2, 0,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_S_Max")
Minimum (1,MRR_PCS_POTENCIA_FASE_S ,FP2,0,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_S_Min")

Average (1,MRR_PCS_COS_FI_FASE_S,FP2,0)
FieldNames ("MRR_PCS_COS_FI_FASE_S_Average")
Maximum (1,MRR_PCS_COS_FI_FASE_S,FP2, 0,0)
FieldNames ("MRR_PCS_COS_FI_FASE_S_Max")
Minimum (1,MRR_PCS_COS_FI_FASE_S,FP2,0,0)
FieldNames ("MRR_PCS_COS_FI_FASE_S_Min")

Average (1,MRR_PCS_CARGA_FASE_S_PCENTO,FP2,0)
FieldNames ("MRR_PCS_CARGA_FASE_S_PCENTO_Average")
Maximum (1,MRR_PCS_CARGA_FASE_S_PCENTO,FP2, 0,0)
FieldNames ("MRR_PCS_CARGA_FASE_S_PCENTO_Max")
Minimum (1,MRR_PCS_CARGA_FASE_S_PCENTO,FP2,0,0)
FieldNames ("MRR_PCS_CARGA_FASE_S_PCENTO_Min")

Average (1,MRR_PCS_TEMP_FASE_S_C ,FP2,0)
FieldNames ("MRR_PCS_TEMP_FASE_S_C_Average")
Maximum (1,MRR_PCS_TEMP_FASE_S_C ,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_FASE_S_C_Max")
Minimum (1,MRR_PCS_TEMP_FASE_S_C ,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_FASE_S_C_Min")

Average (1,MRR_PCS_TEMP_FASE_S_F,FP2,0)
FieldNames ("MRR_PCS_TEMP_FASE_S_F_Average")
Maximum (1,MRR_PCS_TEMP_FASE_S_F,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_FASE_S_F_Max")
Minimum (1,MRR_PCS_TEMP_FASE_S_F,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_FASE_S_F_Min")

Average (1,MRR_PCS_TENSAO_FASE_T,FP2,0)
FieldNames ("MRR_PCS_TENSAO_FASE_T_Average")
Maximum (1,MRR_PCS_TENSAO_FASE_T,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_FASE_T_Max")
Minimum (1,MRR_PCS_TENSAO_FASE_T,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_FASE_T_Min")

Average (1,MRR_PCS_CORRENTE_FASE_T,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_T_Average")
Maximum (1,MRR_PCS_CORRENTE_FASE_T,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_T_Max")
Minimum (1,MRR_PCS_CORRENTE_FASE_T,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_FASE_T_Min")

Average (1,MRR_PCS_TENSAO_INV_FASE_T,FP2,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_T_Average")
Maximum (1,MRR_PCS_TENSAO_INV_FASE_T,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_T_Max")
Minimum (1,MRR_PCS_TENSAO_INV_FASE_T,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_INV_FASE_T_Min")

Average (1,MRR_PCS_CORRENTE_INV_FASE_T,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_T_Average")
Maximum (1,MRR_PCS_CORRENTE_INV_FASE_T,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_T_Max")
Minimum (1,MRR_PCS_CORRENTE_INV_FASE_T,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_INV_FASE_T_Min")

Average (1,MRR_PCS_TENSAO_LINHA_T_R,FP2,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_T_R_Average")
Maximum (1,MRR_PCS_TENSAO_LINHA_T_R,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_T_R_Max")
Minimum (1,MRR_PCS_TENSAO_LINHA_T_R,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_LINHA_T_R_Min")

Average (1,MRR_PCS_POTENCIA_FASE_T ,FP2,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_T_Average")
Maximum (1,MRR_PCS_POTENCIA_FASE_T ,FP2, 0,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_T_Max")
Minimum (1,MRR_PCS_POTENCIA_FASE_T ,FP2,0,0)
FieldNames ("MRR_PCS_POTENCIA_FASE_T_Min")

Average (1,MRR_PCS_COS_FI_FASE_T,FP2,0)
FieldNames ("MRR_PCS_COS_FI_FASE_T_Average")
Maximum (1,MRR_PCS_COS_FI_FASE_T,FP2, 0,0)
FieldNames ("MRR_PCS_COS_FI_FASE_T_Max")
Minimum (1,MRR_PCS_COS_FI_FASE_T,FP2,0,0)
FieldNames ("MRR_PCS_COS_FI_FASE_T_Min")

Average (1,MRR_PCS_CARGA_FASE_T_PCENTO,FP2,0)
FieldNames ("MRR_PCS_CARGA_FASE_T_PCENTO_Average")
Maximum (1,MRR_PCS_CARGA_FASE_T_PCENTO,FP2, 0,0)
FieldNames ("MRR_PCS_CARGA_FASE_T_PCENTO_Max")
Minimum (1,MRR_PCS_CARGA_FASE_T_PCENTO,FP2,0,0)
FieldNames ("MRR_PCS_CARGA_FASE_T_PCENTO_Min")

Average (1,MRR_PCS_TEMP_FASE_T_C ,FP2,0)
FieldNames ("MRR_PCS_TEMP_FASE_T_C_Average")
Maximum (1,MRR_PCS_TEMP_FASE_T_C ,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_FASE_T_C_Max")
Minimum (1,MRR_PCS_TEMP_FASE_T_C ,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_FASE_T_C_Min")

Average (1,MRR_PCS_TEMP_FASE_T_F,FP2,0)
FieldNames ("MRR_PCS_TEMP_FASE_T_F_Average")
Maximum (1,MRR_PCS_TEMP_FASE_T_F,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_FASE_T_F_Max")
Minimum (1,MRR_PCS_TEMP_FASE_T_F,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_FASE_T_F_Min")

Average (1,MRR_PCS_TENSAO_BATERIA_TOTAL,FP2,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_TOTAL_Average")
Maximum (1,MRR_PCS_TENSAO_BATERIA_TOTAL,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_TOTAL_Max")
Minimum (1,MRR_PCS_TENSAO_BATERIA_TOTAL,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_TOTAL_Min")

Average (1,MRR_PCS_TENSAO_BATERIA_BAR_POS,FP2,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_BAR_POS_Average")
Maximum (1,MRR_PCS_TENSAO_BATERIA_BAR_POS,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_BAR_POS_Max")
Minimum (1,MRR_PCS_TENSAO_BATERIA_BAR_POS,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_BAR_POS_Min")

Average (1,MRR_PCS_TENSAO_BATERIA_BAR_NEG,FP2,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_BAR_NEG_Average")
Maximum (1,MRR_PCS_TENSAO_BATERIA_BAR_NEG,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_BAR_NEG_Max")
Minimum (1,MRR_PCS_TENSAO_BATERIA_BAR_NEG,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_BATERIA_BAR_NEG_Min")

Average (1,MRR_PCS_CORRENTE_BATERIA_BAR_POS,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_BATERIA_BAR_POS_Avg")
Maximum (1,MRR_PCS_CORRENTE_BATERIA_BAR_POS,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_BATERIA_BAR_POS_Max")
Minimum (1,MRR_PCS_CORRENTE_BATERIA_BAR_POS,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_BATERIA_BAR_POS_Min")

Average (1,MRR_PCS_CORRENTE_BATERIA_BAR_NEG,FP2,0)
FieldNames ("MRR_PCS_CORRENTE_BATERIA_BAR_NEG_Avg")
Maximum (1,MRR_PCS_CORRENTE_BATERIA_BAR_NEG,FP2, 0,0)
FieldNames ("MRR_PCS_CORRENTE_BATERIA_BAR_NEG_Max")
Minimum (1,MRR_PCS_CORRENTE_BATERIA_BAR_NEG,FP2,0,0)
FieldNames ("MRR_PCS_CORRENTE_BATERIA_BAR_NEG_Min")

Average (1,MRR_PCS_TENSAO_BAR_CC_TOTAL,FP2,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_TOTAL_Average")
Maximum (1,MRR_PCS_TENSAO_BAR_CC_TOTAL,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_TOTAL_Max")
Minimum (1,MRR_PCS_TENSAO_BAR_CC_TOTAL,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_TOTAL_Min")

Average (1,MRR_PCS_TENSAO_BAR_CC_POS,FP2,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_POS_Average")
Maximum (1,MRR_PCS_TENSAO_BAR_CC_POS,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_POS_Max")
Minimum (1,MRR_PCS_TENSAO_BAR_CC_POS,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_POS_Min")

Average (1,MRR_PCS_TENSAO_BAR_CC_NEG,FP2,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_NEG_Average")
Maximum (1,MRR_PCS_TENSAO_BAR_CC_NEG,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_NEG_Max")
Minimum (1,MRR_PCS_TENSAO_BAR_CC_NEG,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_BAR_CC_NEG_Min")

Average (1,MRR_PCS_COMANDO_ANALOG,FP2,0)
FieldNames ("MRR_PCS_COMANDO_ANALOG_Average")
Maximum (1,MRR_PCS_COMANDO_ANALOG,FP2, 0,0)
FieldNames ("MRR_PCS_COMANDO_ANALOG_Max")
Minimum (1,MRR_PCS_COMANDO_ANALOG,FP2,0,0)
FieldNames ("MRR_PCS_COMANDO_ANALOG_Min")

Average (1,MRR_PCS_NIVEL_POT_REQUIS_PCENTO,FP2,0)
FieldNames ("MRR_PCS_NIVEL_POT_REQUIS_PCENTO_Average")
Maximum (1,MRR_PCS_NIVEL_POT_REQUIS_PCENTO,FP2, 0,0)
FieldNames ("MRR_PCS_NIVEL_POT_REQUIS_PCENTO_Max")
Minimum (1,MRR_PCS_NIVEL_POT_REQUIS_PCENTO,FP2,0,0)
FieldNames ("MRR_PCS_NIVEL_POT_REQUIS_PCENTO_Min")

Average (1,MRR_PCS_CARGA_ATUAL,FP2,0)
FieldNames ("MRR_PCS_CARGA_ATUAL_Average")
Maximum (1,MRR_PCS_CARGA_ATUAL,FP2, 0,0)
FieldNames ("MRR_PCS_CARGA_ATUAL_Max")
Minimum (1,MRR_PCS_CARGA_ATUAL,FP2,0,0)
FieldNames ("MRR_PCS_CARGA_ATUAL_Min")

Average (1,MRR_PCS_CARGA_ATUAL_PCENTO,FP2,0)
FieldNames ("MRR_PCS_CARGA_ATUAL_PCENTO_Average")
Maximum (1,MRR_PCS_CARGA_ATUAL_PCENTO,FP2, 0,0)
FieldNames ("MRR_PCS_CARGA_ATUAL_PCENTO_Max")
Minimum (1,MRR_PCS_CARGA_ATUAL_PCENTO,FP2,0,0)
FieldNames ("MRR_PCS_CARGA_ATUAL_PCENTO_Min")

Average (1,MRR_PCS_FREQUENCIA_CA,FP2,0)
FieldNames ("MRR_PCS_FREQUENCIA_CA_Average")
Maximum (1,MRR_PCS_FREQUENCIA_CA,FP2, 0,0)
FieldNames ("MRR_PCS_FREQUENCIA_CA_Max")
Minimum (1,MRR_PCS_FREQUENCIA_CA,FP2,0,0)
FieldNames ("MRR_PCS_FREQUENCIA_CA_Min")

Average (1,MRR_PCS_TEMP_GABINETE_C,FP2,0)
FieldNames ("MRR_PCS_TEMP_GABINETE_C_Average")
Maximum (1,MRR_PCS_TEMP_GABINETE_C,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_GABINETE_C_Max")
Minimum (1,MRR_PCS_TEMP_GABINETE_C,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_GABINETE_C_Min")

Average (1,MRR_PCS_TEMP_GABINETE_F,FP2,0)
FieldNames ("MRR_PCS_TEMP_GABINETE_F_Average")
Maximum (1,MRR_PCS_TEMP_GABINETE_F,FP2, 0,0)
FieldNames ("MRR_PCS_TEMP_GABINETE_F_Max")
Minimum (1,MRR_PCS_TEMP_GABINETE_F,FP2,0,0)
FieldNames ("MRR_PCS_TEMP_GABINETE_F_Min")

Average (1,MRR_PCS_TENSAO_FONTE_INTERNA,FP2,0)
FieldNames ("MRR_PCS_TENSAO_FONTE_INTERNA_Average")
Maximum (1,MRR_PCS_TENSAO_FONTE_INTERNA,FP2, 0,0)
FieldNames ("MRR_PCS_TENSAO_FONTE_INTERNA_Max")
Minimum (1,MRR_PCS_TENSAO_FONTE_INTERNA,FP2,0,0)
FieldNames ("MRR_PCS_TENSAO_FONTE_INTERNA_Min")

Average (1,MRR_PCS_NIVEL_BATERIA_PCENTO,FP2,0)
FieldNames ("MRR_PCS_NIVEL_BATERIA_PCENTO_Average")
Maximum (1,MRR_PCS_NIVEL_BATERIA_PCENTO,FP2, 0,0)
FieldNames ("MRR_PCS_NIVEL_BATERIA_PCENTO_Max")
Minimum (1,MRR_PCS_NIVEL_BATERIA_PCENTO,FP2,0,0)
FieldNames ("MRR_PCS_NIVEL_BATERIA_PCENTO_Min")

Average (1,MRR_PCS_FATOR_POTENCIA,FP2,0)
FieldNames ("MRR_PCS_FATOR_POTENCIA_Average")
Maximum (1,MRR_PCS_FATOR_POTENCIA,FP2, 0,0)
FieldNames ("MRR_PCS_FATOR_POTENCIA_Max")
Minimum (1,MRR_PCS_FATOR_POTENCIA,FP2,0,0)
FieldNames ("MRR_PCS_FATOR_POTENCIA_Min")

Average (1,MRR_PCS_FATOR_POTENCIA_PREC,FP2,0)
FieldNames ("MRR_PCS_FATOR_POTENCIA_PREC_Average")
Maximum (1,MRR_PCS_FATOR_POTENCIA_PREC,FP2, 0,0)
FieldNames ("MRR_PCS_FATOR_POTENCIA_PREC_Max")
Minimum (1,MRR_PCS_FATOR_POTENCIA_PREC,FP2,0,0)
FieldNames ("MRR_PCS_FATOR_POTENCIA_PREC_Min")

Average (1,MRR_PCS_P_REF_AMOSTRADO,FP2,0)
FieldNames ("MRR_PCS_P_REF_AMOSTRADO_Average")
Maximum (1,MRR_PCS_P_REF_AMOSTRADO,FP2, 0,0)
FieldNames ("MRR_PCS_P_REF_AMOSTRADO_Max")
Minimum (1,MRR_PCS_P_REF_AMOSTRADO,FP2,0,0)
FieldNames ("MRR_PCS_P_REF_AMOSTRADO_Min")

Average (1,MRR_PCS_Q_REF_AMOSTRADO,FP2,0)
FieldNames ("MRR_PCS_Q_REF_AMOSTRADO_Average")
Maximum (1,MRR_PCS_Q_REF_AMOSTRADO,FP2, 0,0)
FieldNames ("MRR_PCS_Q_REF_AMOSTRADO_Max")
Minimum (1,MRR_PCS_Q_REF_AMOSTRADO,FP2,0,0)
FieldNames ("MRR_PCS_Q_REF_AMOSTRADO_Min")

EndTable

DataTable (FV_BLOC_C,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)

Average (1,MRR_MM_FV_BLOC_C_VFASE_MEDIA,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_MEDIA_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VFASE_MEDIA,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_MEDIA_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VFASE_MEDIA,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_MEDIA_Min")

Average (1,MRR_MM_FV_BLOC_C_VFASE_A,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_A_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VFASE_A,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_A_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VFASE_A,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_A_Min")

Average (1,MRR_MM_FV_BLOC_C_VFASE_B,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_B_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VFASE_B,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_B_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VFASE_B,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_B_Min")

Average (1,MRR_MM_FV_BLOC_C_VFASE_C,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_C_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VFASE_C,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_C_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VFASE_C,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VFASE_C_Min")

Average (1,MRR_MM_FV_BLOC_C_IFASE_MEDIA,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_MEDIA_Average")
Maximum (1,MRR_MM_FV_BLOC_C_IFASE_MEDIA,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_MEDIA_Max")
Minimum (1,MRR_MM_FV_BLOC_C_IFASE_MEDIA,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_MEDIA_Min")

Average (1,MRR_MM_FV_BLOC_C_IFASE_A ,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_A_Average")
Maximum (1,MRR_MM_FV_BLOC_C_IFASE_A ,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_A_Max")
Minimum (1,MRR_MM_FV_BLOC_C_IFASE_A ,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_A_Min")

Average (1,MRR_MM_FV_BLOC_C_IFASE_B,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_B_Average")
Maximum (1,MRR_MM_FV_BLOC_C_IFASE_B,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_B_Max")
Minimum (1,MRR_MM_FV_BLOC_C_IFASE_B,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_B_Min")

Average (1,MRR_MM_FV_BLOC_C_IFASE_C,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_C_Average")
Maximum (1,MRR_MM_FV_BLOC_C_IFASE_C,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_C_Max")
Minimum (1,MRR_MM_FV_BLOC_C_IFASE_C,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_IFASE_C_Min")

Average (1,MRR_MM_FV_BLOC_C_VLINHA_MEDIA ,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_MEDIA_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VLINHA_MEDIA ,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_MEDIA_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VLINHA_MEDIA ,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_MEDIA_Min")

Average (1,MRR_MM_FV_BLOC_C_VLINHA_AB,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_AB_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VLINHA_AB,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_AB_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VLINHA_AB,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_AB_Min")

Average (1,MRR_MM_FV_BLOC_C_VLINHA_BC,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_BC_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VLINHA_BC,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_BC_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VLINHA_BC,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_BC_Min")

Average (1,MRR_MM_FV_BLOC_C_VLINHA_CA,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_CA_Average")
Maximum (1,MRR_MM_FV_BLOC_C_VLINHA_CA,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_CA_Max")
Minimum (1,MRR_MM_FV_BLOC_C_VLINHA_CA,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_VLINHA_CA_Min")

Average (1,MRR_MM_FV_BLOC_C_FP,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_FP_Average")
Maximum (1,MRR_MM_FV_BLOC_C_FP,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_FP_Max")
Minimum (1,MRR_MM_FV_BLOC_C_FP,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_FP_Min")

Average (1,MRR_MM_FV_BLOC_C_P_TOTAL,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_P_TOTAL_Average")
Maximum (1,MRR_MM_FV_BLOC_C_P_TOTAL,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_P_TOTAL_Max")
Minimum (1,MRR_MM_FV_BLOC_C_P_TOTAL,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_P_TOTAL_Min")

Average (1,MRR_MM_FV_BLOC_C_Q_TOTAL,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_Q_TOTAL_Average")
Maximum (1,MRR_MM_FV_BLOC_C_Q_TOTAL,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_Q_TOTAL_Max")
Minimum (1,MRR_MM_FV_BLOC_C_Q_TOTAL,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_Q_TOTAL_Min")

Average (1,MRR_MM_FV_BLOC_C_S_TOTAL ,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_S_TOTAL_Average")
Maximum (1,MRR_MM_FV_BLOC_C_S_TOTAL ,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_S_TOTAL_Max")
Minimum (1,MRR_MM_FV_BLOC_C_S_TOTAL ,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_S_TOTAL_Min")

Average (1,MRR_MM_FV_BLOC_C_FREQ,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_FREQ_Average")
Maximum (1,MRR_MM_FV_BLOC_C_FREQ,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_FREQ_Max")
Minimum (1,MRR_MM_FV_BLOC_C_FREQ,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_FREQ_Min")

Average (1,MRR_MM_FV_BLOC_C_I_NEUTRO,FP2,0)
FieldNames ("MRR_MM_FV_BLOC_C_I_NEUTRO_Average")
Maximum (1,MRR_MM_FV_BLOC_C_I_NEUTRO,FP2, 0,0)
FieldNames ("MRR_MM_FV_BLOC_C_I_NEUTRO_Max")
Minimum (1,MRR_MM_FV_BLOC_C_I_NEUTRO,FP2,0,0)
FieldNames ("MRR_MM_FV_BLOC_C_I_NEUTRO_Min")
EndTable

DataTable (BAT_2_VIDA_CC,1,-1)
  DataInterval (0,1,Min,10)
  CardOut (0,-1)

  'Sample (1,MRR_BMS1_T,FP2)
  Average (1,MRR_BMS1_T,FP2,0.0)
  FieldNames ("MRR_BMS1_T_Average")
  ' Sample (1,MRR_BMS1_T,FP2)
  Maximum (1,MRR_BMS1_T,FP2, 0.0,0.0)
  FieldNames ("MRR_BMS1_T_Max")
   'Sample (1,MRR_BMS1_T,FP2)
  Minimum (1,MRR_BMS1_T,FP2,0.0,0.0)
  FieldNames ("MRR_BMS1_T_Min")

  Average (1,MRR_BMS1_TMIN,FP2,0)
  FieldNames ("MRR_BMS1_TMIN_Average")
  Maximum (1,MRR_BMS1_TMIN,FP2, 0,0)
  FieldNames ("MRR_BMS1_TMIN_Max")
  Minimum (1,MRR_BMS1_TMIN,FP2,0,0)
  FieldNames ("MRR_BMS1_TMIN_Min")

  Average (1,MRR_BMS1_TMAX,FP2,0)
  FieldNames ("MRR_BMS1_TMAX_Average")
  Maximum (1,MRR_BMS1_TMAX,FP2, 0,0)
  FieldNames ("MRR_BMS1_TMAX_Max")
  Minimum (1,MRR_BMS1_TMAX,FP2,0,0)
  FieldNames ("MRR_BMS1_TMAX_Min")

  Average (1,MRR_BMS1_VMIN_N,FP2,0)
  FieldNames ("MRR_BMS1_VMIN_N_Average")
  Maximum (1,MRR_BMS1_VMIN_N,FP2, 0,0)
  FieldNames ("MRR_BMS1_VMIN_N_Max")
  Minimum (1,MRR_BMS1_VMIN_N,FP2,0,0)
  FieldNames ("MRR_BMS1_VMIN_N_Min")

  Average (1,MRR_BMS1_VMAX_N,FP2,0)
  FieldNames ("MRR_BMS1_VMAX_N_Average")
  Maximum (1,MRR_BMS1_VMAX_N,FP2, 0,0)
  FieldNames ("MRR_BMS1_VMAX_N_Max")
  Minimum (1,MRR_BMS1_VMAX_N,FP2,0,0)
  FieldNames ("MRR_BMS1_VMAX_N_Min")

  Average (1,MRR_BMS1_RMIN_N,FP2,0)
  FieldNames ("MRR_BMS1_RMIN_N_Average")
  Maximum (1,MRR_BMS1_RMIN_N,FP2, 0,0)
  FieldNames ("MRR_BMS1_RMIN_N_Max")
  Minimum (1,MRR_BMS1_RMIN_N,FP2,0,0)
  FieldNames ("MRR_BMS1_RMIN_N_Min")

  Average (1,MRR_BMS1_RMAX_N,FP2,0)
  FieldNames ("MRR_BMS1_RMAX_N_Average")
  Maximum (1,MRR_BMS1_RMAX_N,FP2, 0,0)
  FieldNames ("MRR_BMS1_RMAX_N_Max")
  Minimum (1,MRR_BMS1_RMAX_N,FP2,0,0)
  FieldNames ("MRR_BMS1_RMAX_N_Min")

  Average (1,MRR_BMS1_TMIN_N,FP2,0)
  FieldNames ("MRR_BMS1_TMIN_N_Average")
  Maximum (1,MRR_BMS1_TMIN_N,FP2, 0,0)
  FieldNames ("MRR_BMS1_TMIN_N_Max")
  Minimum (1,MRR_BMS1_TMIN_N,FP2,0,0)
  FieldNames ("MRR_BMS1_TMIN_N_Min")

  Average (1,MRR_BMS1_TMAX_N,FP2,0)
  FieldNames ("MRR_BMS1_TMAX_N_Average")
  Maximum (1,MRR_BMS1_TMAX_N,FP2, 0,0)
  FieldNames ("MRR_BMS1_TMAX_N_Max")
  Minimum (1,MRR_BMS1_TMAX_N,FP2,0,0)
  FieldNames ("MRR_BMS1_TMAX_N_Min")

  Average (1,MRR_BMS1_SOH,FP2,0)
  FieldNames ("MRR_BMS1_SOH_Average")
  Maximum (1,MRR_BMS1_SOH,FP2, 0,0)
  FieldNames ("MRR_BMS1_SOH_Max")
  Minimum (1,MRR_BMS1_SOH,FP2,0,0)
  FieldNames ("MRR_BMS1_SOH_Min")

  Average (1,MRR_BMS1_SOC,FP2,0)
  FieldNames ("MRR_BMS1_SOC_Average")
  Maximum (1,MRR_BMS1_SOC,FP2, 0,0)
  FieldNames ("MRR_BMS1_SOC_Max")
  Minimum (1,MRR_BMS1_SOC,FP2,0,0)
  FieldNames ("MRR_BMS1_SOC_Min")

  Average (1,MRR_BMS1_CHARGE_LIM,FP2,0)
  FieldNames ("MRR_BMS1_CHARGE_LIM_Average")
  Maximum (1,MRR_BMS1_CHARGE_LIM,FP2, 0,0)
  FieldNames ("MRR_BMS1_CHARGE_LIM_Max")
  Minimum (1,MRR_BMS1_CHARGE_LIM,FP2,0,0)
  FieldNames ("MRR_BMS1_CHARGE_LIM_Min")

  Average (1,MRR_BMS1_DISCHARGE_LIM,FP2,0)
  FieldNames ("MRR_BMS1_DISCHARGE_LIM_Average")
  Maximum (1,MRR_BMS1_DISCHARGE_LIM,FP2, 0,0)
  FieldNames ("MRR_BMS1_DISCHARGE_LIM_Max")
  Minimum (1,MRR_BMS1_DISCHARGE_LIM,FP2,0,0)
  FieldNames ("MRR_BMS1_DISCHARGE_LIM_Min")



  Average (1,MRR_BMS2_TMIN,FP2,0)
  FieldNames ("MRR_BMS2_TMIN_Average")
  Maximum (1,MRR_BMS2_TMIN,FP2, 0,0)
  FieldNames ("MRR_BMS2_TMIN_Max")
  Minimum (1,MRR_BMS2_TMIN,FP2,0,0)
  FieldNames ("MRR_BMS2_TMIN_Min")

  Average (1,MRR_BMS2_TMAX,FP2,0)
  FieldNames ("MRR_BMS2_TMAX_Average")
  Maximum (1,MRR_BMS2_TMAX,FP2, 0,0)
  FieldNames ("MRR_BMS2_TMAX_Max")
  Minimum (1,MRR_BMS2_TMAX,FP2,0,0)
  FieldNames ("MRR_BMS2_TMAX_Min")

  Average (1,MRR_BMS2_VMIN_N,FP2,0)
  FieldNames ("MRR_BMS2_VMIN_N_Average")
  Maximum (1,MRR_BMS2_VMIN_N,FP2, 0,0)
  FieldNames ("MRR_BMS2_VMIN_N_Max")
  Minimum (1,MRR_BMS2_VMIN_N,FP2,0,0)
  FieldNames ("MRR_BMS2_VMIN_N_Min")

  Average (1,MRR_BMS2_VMAX_N,FP2,0)
  FieldNames ("MRR_BMS2_VMAX_N_Average")
  Maximum (1,MRR_BMS2_VMAX_N,FP2, 0,0)
  FieldNames ("MRR_BMS2_VMAX_N_Max")
  Minimum (1,MRR_BMS2_VMAX_N,FP2,0,0)
  FieldNames ("MRR_BMS2_VMAX_N_Min")

  Average (1,MRR_BMS2_RMIN_N,FP2,0)
  FieldNames ("MRR_BMS2_RMIN_N_Average")
  Maximum (1,MRR_BMS2_RMIN_N,FP2, 0,0)
  FieldNames ("MRR_BMS2_RMIN_N_Max")
  Minimum (1,MRR_BMS2_RMIN_N,FP2,0,0)
  FieldNames ("MRR_BMS2_RMIN_N_Min")

  Average (1,MRR_BMS2_RMAX_N,FP2,0)
  FieldNames ("MRR_BMS2_RMAX_N_Average")
  Maximum (1,MRR_BMS2_RMAX_N,FP2, 0,0)
  FieldNames ("MRR_BMS2_RMAX_N_Max")
  Minimum (1,MRR_BMS2_RMAX_N,FP2,0,0)
  FieldNames ("MRR_BMS2_RMAX_N_Min")

  Average (1,MRR_BMS2_TMIN_N,FP2,0)
  FieldNames ("MRR_BMS2_TMIN_N_Average")
  Maximum (1,MRR_BMS2_TMIN_N,FP2, 0,0)
  FieldNames ("MRR_BMS2_TMIN_N_Max")
  Minimum (1,MRR_BMS2_TMIN_N,FP2,0,0)
  FieldNames ("MRR_BMS2_TMIN_N_Min")

  Average (1,MRR_BMS2_TMAX_N,FP2,0)
  FieldNames ("MRR_BMS2_TMAX_N_Average")
  Maximum (1,MRR_BMS2_TMAX_N,FP2, 0,0)
  FieldNames ("MRR_BMS2_TMAX_N_Max")
  Minimum (1,MRR_BMS2_TMAX_N,FP2,0,0)
  FieldNames ("MRR_BMS2_TMAX_N_Min")

  Average (1,MRR_BMS2_SOH,FP2,0)
  FieldNames ("MRR_BMS2_SOH_Average")
  Maximum (1,MRR_BMS2_SOH,FP2, 0,0)
  FieldNames ("MRR_BMS2_SOH_Max")
  Minimum (1,MRR_BMS2_SOH,FP2,0,0)
  FieldNames ("MRR_BMS2_SOH_Min")

  Average (1,MRR_BMS2_SOC,FP2,0)
  FieldNames ("MRR_BMS2_SOC_Average")
  Maximum (1,MRR_BMS2_SOC,FP2, 0,0)
  FieldNames ("MRR_BMS2_SOC_Max")
  Minimum (1,MRR_BMS2_SOC,FP2,0,0)
  FieldNames ("MRR_BMS2_SOC_Min")

  Average (1,MRR_BMS2_CHARGE_LIM,FP2,0)
  FieldNames ("MRR_BMS2_CHARGE_LIM_Average")
  Maximum (1,MRR_BMS2_CHARGE_LIM,FP2, 0,0)
  FieldNames ("MRR_BMS2_CHARGE_LIM_Max")
  Minimum (1,MRR_BMS2_CHARGE_LIM,FP2,0,0)
  FieldNames ("MRR_BMS2_CHARGE_LIM_Min")

  Average (1,MRR_BMS2_DISCHARGE_LIM,FP2,0)
  FieldNames ("MRR_BMS2_DISCHARGE_LIM_Average")
  Maximum (1,MRR_BMS2_DISCHARGE_LIM,FP2, 0,0)
  FieldNames ("MRR_BMS2_DISCHARGE_LIM_Max")
  Minimum (1,MRR_BMS2_DISCHARGE_LIM,FP2,0,0)
  FieldNames ("MRR_BMS2_DISCHARGE_LIM_Min")

  Average (1,MRR_SOC_MEDIO,FP2,0)
  FieldNames ("MRR_SOC_MEDIO_Average")
  Maximum (1,MRR_SOC_MEDIO,FP2, 0,0)
  FieldNames ("MRR_SOC_MEDIO_Max")
  Minimum (1,MRR_SOC_MEDIO,FP2,0,0)
  FieldNames ("MRR_SOC_MEDIO_Min")

  Average (1,MRR_BMS_VDC_TOTAL,FP2,0)
  FieldNames ("MRR_BMS_VDC_TOTAL_Average")
  Maximum (1,MRR_BMS_VDC_TOTAL,FP2, 0,0)
  FieldNames ("MRR_BMS_VDC_TOTAL_Max")
  Minimum (1,MRR_BMS_VDC_TOTAL,FP2,0,0)
  FieldNames ("MRR_BMS_VDC_TOTAL_Min")

  Average (1,MRR_BMS_IDC_TOTAL,FP2,0)
  FieldNames ("MRR_BMS_IDC_TOTAL_Average")
  Maximum (1,MRR_BMS_IDC_TOTAL,FP2, 0,0)
  FieldNames ("MRR_BMS_IDC_TOTAL_Max")
  Minimum (1,MRR_BMS_IDC_TOTAL,FP2,0,0)
  FieldNames ("MRR_BMS_IDC_TOTAL_Min")

  Average (1,MRR_BMS1_VDC,FP2,0)
  FieldNames ("MRR_BMS1_VDC_Average")
  Maximum (1,MRR_BMS1_VDC,FP2, 0,0)
  FieldNames ("MRR_BMS1_VDC_Max")
  Minimum (1,MRR_BMS1_VDC,FP2,0,0)
  FieldNames ("MRR_BMS1_VDC_Min")

  Average (1,MRR_BMS1_IDC,FP2,0)
  FieldNames ("MRR_BMS1_IDC_Average")
  Maximum (1,MRR_BMS1_IDC,FP2, 0,0)
  FieldNames ("MRR_BMS1_IDC_Max")
  Minimum (1,MRR_BMS1_IDC,FP2,0,0)
  FieldNames ("MRR_BMS1_IDC_Min")

  Average (1,MRR_BMS1_R,FP2,0)
  FieldNames ("MRR_BMS1_R_Average")
  Maximum (1,MRR_BMS1_R,FP2, 0,0)
  FieldNames ("MRR_BMS1_R_Max")
  Minimum (1,MRR_BMS1_R,FP2,0,0)
  FieldNames ("MRR_BMS1_R_Min")

  Average (1,MRR_BMS1_VMIN,FP2,0)
  FieldNames ("MRR_BMS1_VMIN_Average")
  Maximum (1,MRR_BMS1_VMIN,FP2, 0,0)
  FieldNames ("MRR_BMS1_VMIN_Max")
  Minimum (1,MRR_BMS1_VMIN,FP2,0,0)
  FieldNames ("MRR_BMS1_VMIN_Min")

  Average (1,MRR_BMS1_VMAX,FP2,0)
  FieldNames ("MRR_BMS1_VMAX_Average")
  Maximum (1,MRR_BMS1_VMAX,FP2, 0,0)
  FieldNames ("MRR_BMS1_VMAX_Max")
  Minimum (1,MRR_BMS1_VMAX,FP2,0,0)
  FieldNames ("MRR_BMS1_VMAX_Min")

  Average (1,MRR_BMS1_RMIN,FP2,0)
  FieldNames ("MRR_BMS1_RMIN_Average")
  Maximum (1,MRR_BMS1_RMIN,FP2, 0,0)
  FieldNames ("MRR_BMS1_RMIN_Max")
  Minimum (1,MRR_BMS1_RMIN,FP2,0,0)
  FieldNames ("MRR_BMS1_RMIN_Min")

  Average (1,MRR_BMS1_RMAX,FP2,0)
  FieldNames ("MRR_BMS1_RMAX_Average")
  Maximum (1,MRR_BMS1_RMAX,FP2, 0,0)
  FieldNames ("MRR_BMS1_RMAX_Max")
  Minimum (1,MRR_BMS1_RMAX,FP2,0,0)
  FieldNames ("MRR_BMS1_RMAX_Min")

  Average (1,MRR_BMS2_VDC,FP2,0)
  FieldNames ("MRR_BMS2_VDC_Average")
  Maximum (1,MRR_BMS2_VDC,FP2, 0,0)
  FieldNames ("MRR_BMS2_VDC_Max")
  Minimum (1,MRR_BMS2_VDC,FP2,0,0)
  FieldNames ("MRR_BMS2_VDC_Min")

  Average (1,MRR_BMS2_IDC,FP2,0)
  FieldNames ("MRR_BMS2_IDC_Average")
  Maximum (1,MRR_BMS2_IDC,FP2, 0,0)
  FieldNames ("MRR_BMS2_IDC_Max")
  Minimum (1,MRR_BMS2_IDC,FP2,0,0)
  FieldNames ("MRR_BMS2_IDC_Min")

  Average (1,MRR_BMS2_R,FP2,0)
  FieldNames ("MRR_BMS2_R_Average")
  Maximum (1,MRR_BMS2_R,FP2, 0,0)
  FieldNames ("MRR_BMS2_R_Max")
  Minimum (1,MRR_BMS2_R,FP2,0,0)
  FieldNames ("MRR_BMS2_R_Min")

  Average (1,MRR_BMS2_VMIN,FP2,0)
  FieldNames ("MRR_BMS2_VMIN_Average")
  Maximum (1,MRR_BMS2_VMIN,FP2, 0,0)
  FieldNames ("MRR_BMS2_VMIN_Max")
  Minimum (1,MRR_BMS2_VMIN,FP2,0,0)
  FieldNames ("MRR_BMS2_VMIN_Min")

  Average (1,MRR_BMS2_VMAX,FP2,0)
  FieldNames ("MRR_BMS2_VMAX_Average")
  Maximum (1,MRR_BMS2_VMAX,FP2, 0,0)
  FieldNames ("MRR_BMS2_VMAX_Max")
  Minimum (1,MRR_BMS2_VMAX,FP2,0,0)
  FieldNames ("MRR_BMS2_VMAX_Min")

  Average (1,MRR_BMS2_RMIN,FP2,0)
  FieldNames ("MRR_BMS2_RMIN_Average")
  Maximum (1,MRR_BMS2_RMIN,FP2, 0,0)
  FieldNames ("MRR_BMS2_RMIN_Max")
  Minimum (1,MRR_BMS2_RMIN,FP2,0,0)
  FieldNames ("MRR_BMS2_RMIN_Min")
  
  Average (1,MRR_BMS2_RMAX,FP2,0)
  FieldNames ("MRR_BMS2_RMAX_Average")
  Maximum (1,MRR_BMS2_RMAX,FP2, 0,0)
  FieldNames ("MRR_BMS2_RMAX_Max")
  Minimum (1,MRR_BMS2_RMAX,FP2,0,0)
  FieldNames ("MRR_BMS2_RMAX_Min")

EndTable

DataTable (BAT_2_VIDA,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)

Average (1,MRR_MM_RES_BAT2V_VFASE_MEDIA,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_MEDIA_Average")
Maximum (1,MRR_MM_RES_BAT2V_VFASE_MEDIA,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_MEDIA_Max")
Minimum (1,MRR_MM_RES_BAT2V_VFASE_MEDIA,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_MEDIA_Min")

Average (1,MRR_MM_RES_BAT2V_VFASE_A,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_A_Average")
Maximum (1,MRR_MM_RES_BAT2V_VFASE_A,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_A_Max")
Minimum (1,MRR_MM_RES_BAT2V_VFASE_A,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_A_Min")

Average (1,MRR_MM_RES_BAT2V_VFASE_B,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_B_Average")
Maximum (1,MRR_MM_RES_BAT2V_VFASE_B,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_B_Max")
Minimum (1,MRR_MM_RES_BAT2V_VFASE_B,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_B_Min")

Average (1,MRR_MM_RES_BAT2V_VFASE_C,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_C_Average")
Maximum (1,MRR_MM_RES_BAT2V_VFASE_C,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_C_Max")
Minimum (1,MRR_MM_RES_BAT2V_VFASE_C,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VFASE_C_Min")

Average (1,MRR_MM_RES_BAT2V_IFASE_MEDIA,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_MEDIA_Average")
Maximum (1,MRR_MM_RES_BAT2V_IFASE_MEDIA,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_MEDIA_Max")
Minimum (1,MRR_MM_RES_BAT2V_IFASE_MEDIA,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_MEDIA_Min")

Average (1,MRR_MM_RES_BAT2V_IFASE_A ,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_A_Average")
Maximum (1,MRR_MM_RES_BAT2V_IFASE_A ,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_A_Max")
Minimum (1,MRR_MM_RES_BAT2V_IFASE_A ,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_A_Min")

Average (1,MRR_MM_RES_BAT2V_IFASE_B,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_B_Average")
Maximum (1,MRR_MM_RES_BAT2V_IFASE_B,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_B_Max")
Minimum (1,MRR_MM_RES_BAT2V_IFASE_B,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_B_Min")

Average (1,MRR_MM_RES_BAT2V_IFASE_C,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_C_Average")
Maximum (1,MRR_MM_RES_BAT2V_IFASE_C,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_C_Max")
Minimum (1,MRR_MM_RES_BAT2V_IFASE_C,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_IFASE_C_Min")

Average (1,MRR_MM_RES_BAT2V_VLINHA_MEDIA ,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_MEDIA_Average")
Maximum (1,MRR_MM_RES_BAT2V_VLINHA_MEDIA ,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_MEDIA_Max")
Minimum (1,MRR_MM_RES_BAT2V_VLINHA_MEDIA ,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_MEDIA_Min")

Average (1,MRR_MM_RES_BAT2V_VLINHA_AB,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_AB_Average")
Maximum (1,MRR_MM_RES_BAT2V_VLINHA_AB,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_AB_Max")
Minimum (1,MRR_MM_RES_BAT2V_VLINHA_AB,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_AB_Min")

Average (1,MRR_MM_RES_BAT2V_VLINHA_BC,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_BC_Average")
Maximum (1,MRR_MM_RES_BAT2V_VLINHA_BC,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_BC_Max")
Minimum (1,MRR_MM_RES_BAT2V_VLINHA_BC,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_BC_Min")

Average (1,MRR_MM_RES_BAT2V_VLINHA_CA,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_CA_Average")
Maximum (1,MRR_MM_RES_BAT2V_VLINHA_CA,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_CA_Max")
Minimum (1,MRR_MM_RES_BAT2V_VLINHA_CA,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_VLINHA_CA_Min")

Average (1,MRR_MM_RES_BAT2V_FP,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_FP_Average")
Maximum (1,MRR_MM_RES_BAT2V_FP,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_FP_Max")
Minimum (1,MRR_MM_RES_BAT2V_FP,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_FP_Min")

Average (1,MRR_MM_RES_BAT2V_P_TOTAL,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_P_TOTAL_Average")
Maximum (1,MRR_MM_RES_BAT2V_P_TOTAL,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_P_TOTAL_Max")
Minimum (1,MRR_MM_RES_BAT2V_P_TOTAL,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_P_TOTAL_Min")

Average (1,MRR_MM_RES_BAT2V_Q_TOTAL,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_Q_TOTAL_Average")
Maximum (1,MRR_MM_RES_BAT2V_Q_TOTAL,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_Q_TOTAL_Max")
Minimum (1,MRR_MM_RES_BAT2V_Q_TOTAL,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_Q_TOTAL_Min")

Average (1,MRR_MM_RES_BAT2V_S_TOTAL ,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_S_TOTAL_Average")
Maximum (1,MRR_MM_RES_BAT2V_S_TOTAL ,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_S_TOTAL_Max")
Minimum (1,MRR_MM_RES_BAT2V_S_TOTAL ,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_S_TOTAL_Min")

Average (1,MRR_MM_RES_BAT2V_FREQ,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_FREQ_Average")
Maximum (1,MRR_MM_RES_BAT2V_FREQ,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_FREQ_Max")
Minimum (1,MRR_MM_RES_BAT2V_FREQ,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_FREQ_Min")

Average (1,MRR_MM_RES_BAT2V_I_NEUTRO,FP2,0)
FieldNames ("MRR_MM_RES_BAT2V_I_NEUTRO_Average")
Maximum (1,MRR_MM_RES_BAT2V_I_NEUTRO,FP2, 0,0)
FieldNames ("MRR_MM_RES_BAT2V_I_NEUTRO_Max")
Minimum (1,MRR_MM_RES_BAT2V_I_NEUTRO,FP2,0,0)
FieldNames ("MRR_MM_RES_BAT2V_I_NEUTRO_Min")
EndTable


DataTable (RESERVA,1,-1)
DataInterval (0,1,Min,10)
CardOut (0,-1)

Average (1,MRR_MM_RESERVA_VFASE_MEDIA,FP2,0)
FieldNames ("MRR_MM_RESERVA_VFASE_MEDIA_Average")
Maximum (1,MRR_MM_RESERVA_VFASE_MEDIA,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_MEDIA_Max")
Minimum (1,MRR_MM_RESERVA_VFASE_MEDIA,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_MEDIA_Min")

Average (1,MRR_MM_RESERVA_VFASE_A,FP2,0)
FieldNames ("MRR_MM_RESERVA_VFASE_A_Average")
Maximum (1,MRR_MM_RESERVA_VFASE_A,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_A_Max")
Minimum (1,MRR_MM_RESERVA_VFASE_A,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_A_Min")

Average (1,MRR_MM_RESERVA_VFASE_B,FP2,0)
FieldNames ("MRR_MM_RESERVA_VFASE_B_Average")
Maximum (1,MRR_MM_RESERVA_VFASE_B,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_B_Max")
Minimum (1,MRR_MM_RESERVA_VFASE_B,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_B_Min")

Average (1,MRR_MM_RESERVA_VFASE_C,FP2,0)
FieldNames ("MRR_MM_RESERVA_VFASE_C_Average")
Maximum (1,MRR_MM_RESERVA_VFASE_C,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_C_Max")
Minimum (1,MRR_MM_RESERVA_VFASE_C,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VFASE_C_Min")

Average (1,MRR_MM_RESERVA_IFASE_MEDIA,FP2,0)
FieldNames ("MRR_MM_RESERVA_IFASE_MEDIA_Average")
Maximum (1,MRR_MM_RESERVA_IFASE_MEDIA,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_MEDIA_Max")
Minimum (1,MRR_MM_RESERVA_IFASE_MEDIA,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_MEDIA_Min")

Average (1,MRR_MM_RESERVA_IFASE_A ,FP2,0)
FieldNames ("MRR_MM_RESERVA_IFASE_A_Average")
Maximum (1,MRR_MM_RESERVA_IFASE_A ,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_A_Max")
Minimum (1,MRR_MM_RESERVA_IFASE_A ,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_A_Min")

Average (1,MRR_MM_RESERVA_IFASE_B,FP2,0)
FieldNames ("MRR_MM_RESERVA_IFASE_B_Average")
Maximum (1,MRR_MM_RESERVA_IFASE_B,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_B_Max")
Minimum (1,MRR_MM_RESERVA_IFASE_B,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_B_Min")

Average (1,MRR_MM_RESERVA_IFASE_C,FP2,0)
FieldNames ("MRR_MM_RESERVA_IFASE_C_Average")
Maximum (1,MRR_MM_RESERVA_IFASE_C,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_C_Max")
Minimum (1,MRR_MM_RESERVA_IFASE_C,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_IFASE_C_Min")

Average (1,MRR_MM_RESERVA_VLINHA_MEDIA ,FP2,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_MEDIA_Average")
Maximum (1,MRR_MM_RESERVA_VLINHA_MEDIA ,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_MEDIA_Max")
Minimum (1,MRR_MM_RESERVA_VLINHA_MEDIA ,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_MEDIA_Min")

Average (1,MRR_MM_RESERVA_VLINHA_AB,FP2,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_AB_Average")
Maximum (1,MRR_MM_RESERVA_VLINHA_AB,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_AB_Max")
Minimum (1,MRR_MM_RESERVA_VLINHA_AB,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_AB_Min")

Average (1,MRR_MM_RESERVA_VLINHA_BC,FP2,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_BC_Average")
Maximum (1,MRR_MM_RESERVA_VLINHA_BC,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_BC_Max")
Minimum (1,MRR_MM_RESERVA_VLINHA_BC,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_BC_Min")

Average (1,MRR_MM_RESERVA_VLINHA_CA,FP2,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_CA_Average")
Maximum (1,MRR_MM_RESERVA_VLINHA_CA,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_CA_Max")
Minimum (1,MRR_MM_RESERVA_VLINHA_CA,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_VLINHA_CA_Min")

Average (1,MRR_MM_RESERVA_FP,FP2,0)
FieldNames ("MRR_MM_RESERVA_FP_Average")
Maximum (1,MRR_MM_RESERVA_FP,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_FP_Max")
Minimum (1,MRR_MM_RESERVA_FP,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_FP_Min")

Average (1,MRR_MM_RESERVA_P_TOTAL,FP2,0)
FieldNames ("MRR_MM_RESERVA_P_TOTAL_Average")
Maximum (1,MRR_MM_RESERVA_P_TOTAL,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_P_TOTAL_Max")
Minimum (1,MRR_MM_RESERVA_P_TOTAL,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_P_TOTAL_Min")

Average (1,MRR_MM_RESERVA_Q_TOTAL,FP2,0)
FieldNames ("MRR_MM_RESERVA_Q_TOTAL_Average")
Maximum (1,MRR_MM_RESERVA_Q_TOTAL,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_Q_TOTAL_Max")
Minimum (1,MRR_MM_RESERVA_Q_TOTAL,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_Q_TOTAL_Min")

Average (1,MRR_MM_RESERVA_S_TOTAL ,FP2,0)
FieldNames ("MRR_MM_RESERVA_S_TOTAL_Average")
Maximum (1,MRR_MM_RESERVA_S_TOTAL ,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_S_TOTAL_Max")
Minimum (1,MRR_MM_RESERVA_S_TOTAL ,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_S_TOTAL_Min")

Average (1,MRR_MM_RESERVA_FREQ,FP2,0)
FieldNames ("MRR_MM_RESERVA_FREQ_Average")
Maximum (1,MRR_MM_RESERVA_FREQ,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_FREQ_Max")
Minimum (1,MRR_MM_RESERVA_FREQ,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_FREQ_Min")

Average (1,MRR_MM_RESERVA_I_NEUTRO,FP2,0)
FieldNames ("MRR_MM_RESERVA_I_NEUTRO_Average")
Maximum (1,MRR_MM_RESERVA_I_NEUTRO,FP2, 0,0)
FieldNames ("MRR_MM_RESERVA_I_NEUTRO_Max")
Minimum (1,MRR_MM_RESERVA_I_NEUTRO,FP2,0,0)
FieldNames ("MRR_MM_RESERVA_I_NEUTRO_Min")
EndTable



'Define Subroutines
'Sub
	'EnterSub instructions here
'EndSub

'Main Program
BeginProg
  StationName ("BESS_CR6")
	Scan (1,Sec,0,0)
	  Socket=TCPOpen(Samsung_Addr,Samsung_Port,1,500,Samsung_Handle,10)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_warranty,13388,9,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_warranty_external,13248,3,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_qdca,13888,18,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_Blocos_A_B,13948,18,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_Bloco_C,14008,18,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_Carr_eBus,14068,18,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_FV_Blocos_A_B,14128,18,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_PCS(),14428,18,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_PCS_real(),14488,52,3,100,2)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_FV_BLOC_C(),14188,18,3,100,2)'14190 ate 14222
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_BAT_2_VIDA(),14308,18,3,100,2)'14308 ate 14342
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_RESERVA(),14368,18,3,100,2)'14368 ate 14342
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_BAT_2_VIDA_1,16308,13,3,100,1)' 16308 int (adjusted to read 13 variables, each using 1 register)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_BAT_2_VIDA_2,16336,14,3,100,1)' 16336 int (adjusted to read 14 variables, each using 1 register)
    ModbusMaster (Result,Socket,-9600,1,3,Modbus_BAT_2_VIDA_3(),16350,16,3,100,2)' 16350 float (adjusted to read 16 variables, each using 2 registers)

    CallTable GARANTIA
    CallTable QDCA
    CallTable Blocos_A_B
    CallTable Bloco_C
    CallTable Carr_eBus
    CallTable FV_Blocos_A_B
    CallTable PCS
    CallTable PCS_real
    CallTable FV_BLOC_C
    CallTable BAT_2_VIDA
    CallTable BAT_2_VIDA_CC
    CallTable RESERVA
	NextScan
EndProg


