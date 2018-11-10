using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    public class Character : INotifyPropertyChanged, IDataErrorInfo
    {
        private string lastName, firstName, height, weight;
        private DateTime born;
        /*
        // Basic Information
        private string lastName,
            firstName,
            age,
            nationality,
            hometown,
            curhome,
            occupation,
            income,
            talentOrSkill,
            salary,
            birthOrder,
            siblings,
            spouse,
            children,
            grandparents,
            grandchildren,
            significantOthers,
            relationshpSkills,
            role;

        // Physical Characteristics
        private string height,
            weight,
            race,
            eyeColor,
            hairColor,
            skinColor,
            sightAid,
            faceShape,
            distinguishedFeatures,
            dress,
            mannerisms,
            habits,
            health,
            hobbies,
            favoriteQuotes,
            speechPattern,
            disabilities,
            style,
            flaws,
            qualities;

        // Intellectual/Mental/Personality Attributes and Attitudes
        private string education,
            mentalIllness,
            learningExperiences,
            shortGoals,
            longGoals,
            selfReflection,
            othersReflection,
            selfEsteem,
            logicEmotion,
            embarrassement;

        // Emotional
        private string strengths,
            weaknesses,
            verted,
            anger,
            sadness,
            conflict,
            change,
            loss,
            life,
            motivation,
            frightens,
            happy,
            judgmental,
            giving,
            friendly;

        // Relationship Mapping
        private string relationships;

        // Religous
        private string beliefs, religousRoles, behaviorChange;*/

        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value?.Length > 10)
                    throw new ArgumentOutOfRangeException(nameof(FirstName), value, "Cannot be > 10 characters.");
                SetField(ref firstName, value);
                validateFieldsNotEmpty();
                OnPropertyChanged(nameof(Name));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (value?.Length > 10)
                    throw new ArgumentOutOfRangeException(nameof(FirstName), value, "Cannot be > 10 characters.");
                SetField(ref lastName, value);
                validateFieldsNotEmpty();
                OnPropertyChanged(nameof(Name));
            }
        }

        public DateTime Born
        {
            get { return born; }
            set
            {
                SetField(ref born, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Height
        {
            get { return height; }
            set
            {
                if (value?.Length > 10)
                    throw new ArgumentOutOfRangeException(nameof(FirstName), value, "Cannot be > 10 characters.");
                SetField(ref height, value);
                validateFieldsNotEmpty();
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Weight
        {
            get { return weight; }
            set
            {
                if (value?.Length > 10)
                    throw new ArgumentOutOfRangeException(nameof(FirstName), value, "Cannot be > 10 characters.");
                SetField(ref weight, value);
                OnPropertyChanged(nameof(Name));
            }
        }
        private bool isFieldsEmpty;
        public bool IsFieldsEmpty
        {
            get { return isFieldsEmpty; }
            set
            {
                SetField(ref isFieldsEmpty, value);
                validateFieldsNotEmpty();
            }
        }

        private void validateFieldsNotEmpty()
        {
            if (FirstName == null)
                errors[nameof(IsFieldsEmpty)] = "First name can't be empty";
            else if (LastName == null)
                errors[nameof(IsFieldsEmpty)] = "Last name can't be empty";
            else if (Weight == null)
                errors[nameof(IsFieldsEmpty)] = "Weight can't be empty";
            else if (Height == null)
                errors[nameof(IsFieldsEmpty)] = "Height can't be empty";
            else
                errors[nameof(IsFieldsEmpty)] = null;

            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(Weight));
        }

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => errors.ContainsKey(columnName) ? errors[columnName] : null;
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

    }
}
