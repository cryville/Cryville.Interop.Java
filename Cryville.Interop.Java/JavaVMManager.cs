using System;
using System.Collections.Generic;

namespace Cryville.Interop.Java {
	/// <summary>
	/// Java VM manager.
	/// </summary>
	public static class JavaVMManager {
		/// <summary>
		/// Registers a Java VM.
		/// </summary>
		/// <param name="vm">A Java VM.</param>
		/// <exception cref="ArgumentNullException"><paramref name="vm" /> is <see langword="null" />.</exception>
		public static void Register(IJniInvoke vm) {
			if (vm == null) throw new ArgumentNullException(nameof(vm));
			if (m_vms.Contains(vm)) return;
			m_vms.Add(vm);
			m_currentVM ??= vm;
		}

		static readonly List<IJniInvoke> m_vms = [];
		/// <summary>
		/// All registered Java VMs.
		/// </summary>
		public static IEnumerable<IJniInvoke> VMs => m_vms;

		static IJniInvoke? m_currentVM;
		/// <summary>
		/// The first VM registered.
		/// </summary>
		public static IJniInvoke? CurrentVM => m_currentVM;
		/// <summary>
		/// The <see cref="IJniEnv" /> of the first VM registered.
		/// </summary>
		public static IJniEnv CurrentEnv => CurrentVM?.GetEnv(0x00010006) ?? throw new InvalidOperationException("No VM registered");
	}
}
