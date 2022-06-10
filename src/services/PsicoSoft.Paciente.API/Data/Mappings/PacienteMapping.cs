using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PsicoSoft.Core.DomainObjects;

namespace PsicoSoft.Pacientes.API.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<PsicoSoft.Pacientes.API.Models.Paciente>
    {
        public void Configure(EntityTypeBuilder<PsicoSoft.Pacientes.API.Models.Paciente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.CPF, tf =>
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            // 1 : 1 => Paciente : Endereco
            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Paciente);

            builder.ToTable("Pacientes");
        }

    }
}
