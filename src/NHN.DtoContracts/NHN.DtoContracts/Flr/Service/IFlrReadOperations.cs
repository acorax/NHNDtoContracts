﻿using System.Collections.Generic;
using System.ServiceModel;
using NHN.DtoContracts.Common.en;
using System;
using NHN.DtoContracts.Flr.Data;

namespace NHN.DtoContracts.Flr.Service
{
    /// <summary>
    /// Leseoperasjoner for FLR (GP v2)
    /// </summary>
    [ServiceContract(Namespace = FlrXmlNamespace.V1)]
    public interface IFlrReadOperations
    {
        /// <summary>
        /// Henter fastlege for en gitt person.
        /// </summary>
        /// <param name="patientNin"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetails GetPatientGPDetails(string patientNin);

        /// <summary>
        /// Henter fastlegebytte historikken
        /// </summary>
        /// <param name="patientNin"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<PatientToGPContractAssociation> GetPatientGPHistory(string patientNin);

        /// <summary>
        /// Henter en enkelt fastlegeavtale
        /// </summary>
        /// <param name="gpContractId">Kontraktens id.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPContract GetGPContract(long gpContractId);

        /// <summary>
        /// Henter fastlegeavtaler tilknyttet virksomheten på et gitt tidspunkt. Hvis tidspunktet er NULL, så returneres alle kontrakter inklusive historiske.
        /// </summary>
        /// <param name="organizationNumber">Legekontor orgnummer</param>
        /// <param name="atTime">Hent kontrakter for dette tidspunktet. NULL for historiske.</param>
        /// <returns>Alle kontrakter på relevant tidspunkt.</returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<GPContract> GetGPContractsOnOffice(int organizationNumber, DateTime? atTime);

        /// <summary>
        /// Henter fastlegeliste.
        /// </summary>
        /// <param name="gpContractId">Fastlegeavtalen.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        ICollection<PatientToGPContractAssociation> GetGPPatientList(long gpContractId);

        /// <summary>
        /// Henter fastlege og tilhørende praksis(er)
        /// </summary>
        /// <param name="hprNumber">Legens HPR-nummer.</param>
        /// <param name="atTime">Hvis null, historiske og framtidige. Hvis satt, kun kontrakter relevant på det tidspunkt.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        GPDetails GetGPWithAssociatedGPContracts(int hprNumber, DateTime? atTime);

        /// <summary>
        /// Sjekker om en lege er pasientens fastlege på et gitt tidspunkt
        /// </summary>
        /// <param name="patientNin"></param>
        /// <param name="hprNumber">Legens HPR-nummer.</param>
        /// <param name="atTime">Hvis null, akkurat nå. Hvis satt, sjekk om legen var fastlege på det tidspunkt.</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(GenericFault))]
        bool ConfirmGP(string patientNin, int hprNumber, DateTime? atTime);
    }
}
