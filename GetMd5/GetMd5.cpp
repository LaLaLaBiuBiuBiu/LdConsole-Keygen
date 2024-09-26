#include <windows.h>
#include <iostream>
#include <thread>
#include <fstream>
char str[33] = { 0 };
typedef void(__stdcall* DllTrRegInit)(char* str1, int* ptr1, char* str2, int* ptr2);
static void Call_DllTrRegInit(int adress);
static void InsertSoftwareBreakpoint(void* address);
static bool SetHardwareBreakpoint(void* addr);
static LONG WINAPI ExceptionHandler(EXCEPTION_POINTERS* ExceptionInfo);
static void WriteFile();
int main()
{
	AddVectoredExceptionHandler(0, ExceptionHandler);
	Call_DllTrRegInit(0xae09);
	return 0;
}

static void Call_DllTrRegInit(int adress)
{
	char* bu1 = new char[15] {"leaderPfv1.lic"};
	char* bu2 = new char[4] {"901"};
	HINSTANCE hDll = LoadLibrary(L"TrRInfo.dll");
	if (hDll == NULL) {
		std::cerr << "DLL loading failed" << std::endl;
		return;
	}
	else {
		void* funcAddr = (void*)((uintptr_t)hDll + adress);
		InsertSoftwareBreakpoint(funcAddr);
		std::cout << "The loading base address of hDll: " << hDll << std::endl;
	}

	DllTrRegInit init = (DllTrRegInit)GetProcAddress(hDll, "DllTrRegInit");
	if (init == NULL) {
		std::cerr << "Failed to load Func" << std::endl;
	}
	else {
		std::cout << "Call start" << std::endl;
		init(bu1, NULL, bu2, NULL);
		std::cout << "Call completed" << std::endl;
	}

	FreeLibrary(hDll);
	delete[] bu1;
	delete[] bu2;
}
static void InsertSoftwareBreakpoint(void* address)
{
	DWORD oldProtect;
	VirtualProtect(address, 1, PAGE_EXECUTE_READWRITE, &oldProtect);
	*(BYTE*)address = 0xCC;
	VirtualProtect(address, 1, oldProtect, &oldProtect);
}
static bool SetHardwareBreakpoint(void* addr)
{
	HANDLE hThread = GetCurrentThread();
	CONTEXT context;
	context.ContextFlags = CONTEXT_DEBUG_REGISTERS;
	if (GetThreadContext(hThread, &context) == 0) {
		std::cerr << "Error getting thread context!" << std::endl;
		return false;
	}
	context.Dr0 = reinterpret_cast<DWORD_PTR>(addr);
	context.Dr7 = (1 << 0) | (0 << 16);
	if (SetThreadContext(hThread, &context) == 0) {
		std::cerr << "Error setting thread context!" << std::endl;
		return false;
	}

	return true;
}
static LONG WINAPI ExceptionHandler(EXCEPTION_POINTERS* ExceptionInfo)
{
	CONTEXT* context = ExceptionInfo->ContextRecord;
	switch (ExceptionInfo->ExceptionRecord->ExceptionCode)
	{
	case EXCEPTION_SINGLE_STEP:
	case  EXCEPTION_BREAKPOINT:
		std::cout << "EXCEPTION_BREAKPOINT" << std::endl;
		std::cout << "EDX: " << std::hex << context->Edx << std::endl;
		std::cout << "EIP: " << std::hex << context->Eip << std::endl;

		if (context->Edx != 0) {
			__try {
				memcpy(str, (char*)context->Edx, 32);
				str[32] = '\0';
			}
			__except (EXCEPTION_EXECUTE_HANDLER) {
				std::cerr << "Unable to read the string pointed to by EDX!" << std::endl;
			}
		}
		WriteFile();
		exit(0);
		context->Eip += 1;
		break;
	}

	return EXCEPTION_CONTINUE_EXECUTION;
}
static void WriteFile()
{
	std::ofstream file("MD5.txt");

	if (file.is_open()) {
		file << str;
		file.close();
		std::cout << "Write successfully ！" << std::endl;
	}
	else {
		std::cerr << "Unable to open file！" << std::endl;
	}
}